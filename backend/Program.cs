using backend.Services;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ITicketService, TicketService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Âêëþ÷àåì Scalar (çàìåíà Swagger UI)
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// --- ÍÀØÈ ÑËÓÆÅÁÍÛÅ ÀÄÐÅÑÀ ---
app.MapGet("/health", () => Results.Ok("Healthy"));

app.MapGet("/info", () => Results.Ok(new
{
    AppName = "Equipment Repair API",
    Environment = app.Environment.EnvironmentName,
    Version = "ËÐ7"
}));
// ------------------------------

app.MapControllers();

app.Run();