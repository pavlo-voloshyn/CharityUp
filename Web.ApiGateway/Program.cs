using Web.ApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("AccountService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Account"]);
});
builder.Services.AddHttpClient("FoundationService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Foundation"]);
});
builder.Services.AddHttpClient("PaymentService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Payment"]);
});
builder.Services.AddHttpClient("SubscriptionService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Subscription"]);
});
builder.Services.AddSingleton<AccountHttpClientService>();
builder.Services.AddSingleton<FoundationHttpClientService>();
builder.Services.AddSingleton<PaymentHttpClientService>();
builder.Services.AddSingleton<SubscriptionHttpClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
