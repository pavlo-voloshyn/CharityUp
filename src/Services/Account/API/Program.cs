using AccountService.API.Filters;
using AccountService.API.Middleware;
using AccountService.Application.DIConfiguration;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Start Application");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureAccountDbContext(builder.Configuration.GetConnectionString("AccountDb"));
    builder.Services.ConfigureIdentityServer();
    builder.Services.ConfigureJwtSettings(builder.Configuration.GetSection("JwtSettings"));
    builder.Services.AddAutoMapper();
    builder.Services.AddRepositories();
    builder.Services.AddServices();
    builder.Services.AddScoped<AuditLoggingAttribute>();
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.MapControllers();

    app.UseCors(builder => builder.AllowAnyOrigin());

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    logger.Info("Shutting down application");
    LogManager.Shutdown();
}
