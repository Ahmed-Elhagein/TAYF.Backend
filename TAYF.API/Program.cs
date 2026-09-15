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
using TAYF.Infrastructure.Seed;
using TAYF.Application.Scada;
using TAYF.Infrastructure.Scada;

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

builder.Services.AddScoped<ScadaCsvSeeder>();
builder.Services.AddScoped<SoilingAnalysisSeeder>();

// SCADA
builder.Services.AddScoped<IScadaDataSource, CsvScadaDataSource>();
builder.Services.AddSingleton<IScadaStreamPublisher, ChannelScadaStreamPublisher>();
builder.Services.AddSingleton<IScadaSimulationClock, ScadaSimulationClock>();
builder.Services.AddHostedService<ScadaSimulationBackgroundService>();

builder.Services.AddHttpClient<IRootCauseModelClient, TAYF.Infrastructure.Ai.AiRootCauseModelClient>(client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["AiModel:BaseUrl"] ?? "http://localhost:8000");
    client.Timeout = TimeSpan.FromSeconds(30);
});


builder.Services.AddScoped<TelemetryDtoValidator>();

builder.Services.AddMemoryCache();
builder.Services.AddHostedService<TelemetryAnalysisBackgroundService>();

// Cleaning Decision
builder.Services.AddScoped<ICleaningDecisionService, CleaningDecisionService>();

// Plant Dashboard
builder.Services.AddScoped<IPlantDashboardService, PlantDashboardService>();

// Demo Scenario
builder.Services.AddScoped<IDemoScenarioService, DemoScenarioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FlutterDev", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TayfDbContext>();
    await db.Database.MigrateAsync();
}

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var scadaSeeder = scope.ServiceProvider.GetRequiredService<ScadaCsvSeeder>();
    await scadaSeeder.SeedAsync();

    var soilingSeeder = scope.ServiceProvider.GetRequiredService<SoilingAnalysisSeeder>();
    await soilingSeeder.SeedAsync();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("FlutterDev");

app.UseAuthorization();

app.MapControllers();

app.Run();