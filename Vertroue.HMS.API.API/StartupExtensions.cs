using Vertroue.HMS.API.Api.Middleware;
using Vertroue.HMS.API.Api.Services;
using Vertroue.HMS.API.Api.Utility;
using Vertroue.HMS.API.Application;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Infrastructure;
using Vertroue.HMS.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.Features;

namespace Vertroue.HMS.API.Api
{
    [ExcludeFromCodeCoverage]
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder, IConfiguration configuration)
        {
            AddSwagger(builder.Services, configuration);

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 1073741824; // 1GB limit in bytes
            });

            // TODO: Add below lines once we have APP Insights ready
            //var aiOptions = new ApplicationInsightsServiceOptions
            //{
            //    ConnectionString = configuration["ApplicationInsights:ConnectionString"],
            //    EnableAdaptiveSampling = false
            //};

            //builder.Services.AddApplicationInsightsTelemetry(aiOptions);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(configuration);
            builder.Services.AddPersistenceServices(configuration);
            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthAppName("Swagger Client");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(StartupExtensions)?.Namespace?.Replace(".", " "));
                c.OAuthClientId(configuration["AzureAd:ClientId"]);
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseCustomExceptionHandler();

            if (configuration.GetValue<bool>("EnableRequestResponseLoggingMiddleware"))
            {
                app.UseMiddleware<RequestResponseLoggingMiddleware>(configuration.GetValue("RequestResponseLoggingMiddlewareBufferSize", 4096));
            }

            app.UseCors("Open");

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
        private static void AddSwagger(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Description = "oauth2",
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri(configuration["AzureAd:Instance"] + configuration["AzureAd:TenantId"] + "/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri(configuration["AzureAd:Instance"] + "common/" + configuration["AzureAd:TenantId"] + "/v2.0/token"),
                            Scopes = configuration.GetSection("AzureAd:Scopes").Get<Dictionary<string, string>>()?.ToDictionary(pair => $"api://{configuration["AzureAd:ClientId"]}/{pair.Key}", pair => pair.Value)
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                          },
                          Scheme = "oauth2",
                          Name = "oauth2",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = typeof(StartupExtensions)?.Namespace?.Replace(".", " "),

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        public static async Task MigrateDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<ApiDbContext>();
                if (context != null)
                {
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}