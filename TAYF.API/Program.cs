using Microsoft.EntityFrameworkCore;
using TAYF.Infrastructure;
using TAYF.Application.Services;
using TAYF.Application.Validators;
using TAYF.Infrastructure.Data;
using TAYF.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;

using TAYF.Application.Interfaces;
using TAYF.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// ✅ ضيف السطرين دول
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework Core services
builder.Services.AddDbContext<TayfDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add the application DbContext interface registration
builder.Services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<TayfDbContext>());

// Configure RepairVerificationSettings
builder.Services.Configure<RepairVerificationSettings>(builder.Configuration.GetSection("RepairVerificationSettings"));

// Add application services
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

// Add infrastructure services
builder.Services.AddSingleton<IRootCauseModelClient, MockRootCauseModelClient>();

// Add validators
builder.Services.AddScoped<TelemetryDtoValidator>();

builder.Services.AddMemoryCache();
builder.Services.AddHostedService<TelemetryAnalysisBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();        // ✅ ضيف ده
    app.UseSwaggerUI();      // ✅ وضيف ده
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();