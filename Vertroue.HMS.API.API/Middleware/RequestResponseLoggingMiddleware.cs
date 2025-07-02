using Microsoft.ApplicationInsights;
using Microsoft.IdentityModel.Abstractions;

using System.Text;
public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly TelemetryClient _telemetryClient;
    private readonly int _maxBodyLogSize;
    public RequestResponseLoggingMiddleware(RequestDelegate next, TelemetryClient telemetryClient, int maxBodyLogSize = 4096)
    {
        _next = next;
        _telemetryClient = telemetryClient;
        _maxBodyLogSize = maxBodyLogSize;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        // Check if the request is for an API endpoint
        if (context.Request.Path.StartsWithSegments("/api"))
        {
            context.Request.EnableBuffering();
            // Log request data
            var requestBody = await ReadStreamInChunksAsync(context.Request.Body, _maxBodyLogSize);
            context.Request.Body.Position = 0;
            // Log request headers and body as a custom event
            _telemetryClient.TrackEvent("RequestData", new Dictionary<string, string>
        {
            { "Method", context.Request.Method },
            { "Scheme", context.Request.Scheme },
            { "Host", context.Request.Host.ToString() },
            { "Path", context.Request.Path },
            { "QueryString", context.Request.QueryString.ToString() },
            { "Headers", FormatHeaders(context.Request.Headers) },
            { "Body", requestBody }
        });
            // Replace the original response body stream with a new MemoryStream
            var originalResponseBodyStream = context.Response.Body;
            using var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;
            await _next(context);
            // Log response data
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await ReadStreamInChunksAsync(responseBodyStream, _maxBodyLogSize);
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            // Log response headers and body as a custom event
            _telemetryClient.TrackEvent("ResponseData", new Dictionary<string, string>
        {
            { "StatusCode", context.Response.StatusCode.ToString() },
            { "Headers", FormatHeaders(context.Response.Headers) },
            { "Body", responseBody }
        });
            // Copy the contents of the new MemoryStream to the original stream
            await responseBodyStream.CopyToAsync(originalResponseBodyStream);
        }
        else
        {
            // Proceed without logging if the request is not for an API endpoint
            await _next(context);
        }
    }
    private async Task<string> ReadStreamInChunksAsync(Stream stream, int maxSize)
    {
        // Create a copy of the original stream using a MemoryStream
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        stream.Position = 0;
        memoryStream.Position = 0;
        using var reader = new StreamReader(memoryStream, leaveOpen: true);
        var stringBuilder = new StringBuilder();
        char[] buffer = new char[4096];
        int bytesRead;
        int totalBytesRead = 0;
        while ((bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0 && totalBytesRead < maxSize)
        {
            totalBytesRead += bytesRead;
            stringBuilder.Append(buffer, 0, bytesRead);
        }
        return stringBuilder.ToString();
    }
    private string FormatHeaders(IHeaderDictionary headers)
    {
        var formattedHeaders = new StringBuilder();
        foreach (var header in headers)
        {
            formattedHeaders.Append($"{header.Key}: {header.Value}; ");
        }
        return formattedHeaders.ToString().TrimEnd(' ', ';');
    }
}
