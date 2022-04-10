using ANCSG.API.Configuration;
using ANCSG.API.Services;
using ANCSG.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHostedService<DoctorRegisteredIntegrationHandler>();
builder.Services.AddHostedService<PatientRegisteredIntegrationHandler>();
builder.Services.AddHostedService<DoctorExamScheduledIntegrationHandler>();
builder.Services.AddHostedService<PatientExamScheduledIntegrationHandler>();

var app = builder.Build();

app.UseSwaggerConfig();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
