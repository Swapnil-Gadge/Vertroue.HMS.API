using Vertroue.HMS.API.Api;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var app = builder
       .ConfigureServices(configuration)
       .ConfigurePipeline(configuration);

// below line is not required as we are using DB first approach
//await app.MigrateDatabaseAsync();

app.Run();

public partial class Program { }