using Newshore.Viajes.Api.Middleware;
using Newshore.Viajes.Application.ApplicationService;
using Newshore.Viajes.Application.IApplicationService;
using Newshore.Viajes.Business.IServices;
using Newshore.Viajes.Business.Services;
using Newshore.Viajes.Communications.IServices;
using Newshore.Viajes.Communications.Services;
using Serilog;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
try
{
    logger.Information("Application is starting");

    // Add services to the container.

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    // Agregar Servicios al contenedor de dependencias
    builder.Services.AddTransient<IApiFlights, ApiFlights>();
    builder.Services.AddTransient<ISearchFlightService, SearchFlightService>();
    builder.Services.AddTransient<ISearchFlightApplicationService, SearchFlightApplicationService>();

    builder.Services.AddSwaggerGen();

    // Serilog
    builder.Host.ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Warning);
    }).UseSerilog((HostBuilderContext context, LoggerConfiguration loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(context.Configuration);
    });

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

    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, ex.Message);
}
