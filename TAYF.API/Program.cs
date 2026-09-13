using Microsoft.EntityFrameworkCore;
using TAYF.Infrastructure;
using TAYF.Application.Services;
using TAYF.Application.Validators;
using TAYF.Infrastructure.Data;
using TAYF.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using TAYF.API.Middleware;
using TAYF.Application.Interfaces;
using TAYF.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TayfDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<TayfDbContext>());

builder.Services.Configure<RepairVerificationSettings>(builder.Configuration.GetSection("RepairVerificationSettings"));

builder.Services.AddScoped<ITelemetryService, TelemetryService>();
builder.Services.AddScoped<IExpectedPowerService, BaselineExpectedPowerService>();
builder.Services.AddScoped<IAnomalyDetectionService, AnomalyDetectionService>();
builder.Services.AddScoped<IPlantStatusService, PlantStatusService>();
builder.Services.AddScoped<IRootCauseService, RootCauseService>();
builder.Services.AddScoped<IRepairVerificationService, RepairVerificationService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IEnergyLossAnalysisService, EnergyLossAnalysisService>();
builder.Services.AddScoped<IFinancialLossAnalysisService, FinancialLossAnalysisService>();
builder.Services.AddScoped<IEconomicImpactService, EconomicImpactService>();
builder.Services.AddScoped<IPerformanceService, PerformanceService>();
builder.Services.AddScoped<IMaintenancePriorityService, MaintenancePriorityService>();

builder.Services.AddSingleton<IRootCauseModelClient, MockRootCauseModelClient>();

builder.Services.AddScoped<TelemetryDtoValidator>();

builder.Services.AddMemoryCache();
builder.Services.AddHostedService<TelemetryAnalysisBackgroundService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();