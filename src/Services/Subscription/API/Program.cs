using NLog;
using NLog.Web;
using SubscriptionService.API.Filters;
using SubscriptionService.API.Middleware;
using SubscriptionService.Application.DIConfiguration;

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
    builder.Services.ConfigureSubscriptionDbContext(builder.Configuration.GetConnectionString("SubscriptionDb"));
    builder.Services.AddAutoMapper();
    builder.Services.AddRepositories();
    builder.Services.AddServices();
    builder.Services.AddScoped<AuditLoggingAttribute>();
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();
    builder.Services.ConfigureQuartz();

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
