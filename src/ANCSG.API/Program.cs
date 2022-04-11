using ANCSG.API.Configuration;
using ANCSG.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.ConfigureVersion();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.ConfigureBackgroundServices();

var app = builder.Build();

app.UseSwaggerConfig();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
