using GameFrontend.Endpoints;
using GameFrontend.OpenMatch;
using Microsoft.Extensions.Http.Resilience;
using OpenTelemetry.Metrics;
using Serilog;
using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new CompactJsonFormatter())
    .CreateLogger();

var builder = WebApplication.CreateSlimBuilder(args);   // .NET 8 + AOT
//var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcClient<FrontendService.FrontendServiceClient>(Constants.OpenMatchFrontend, o =>
{
    var address = builder.Configuration["OPENMATCH_FRONTEND_HOST"] ??
                  "http://open-match-frontend.open-match.svc.cluster.local:50504";
    o.Address = new Uri(address);
}).ConfigureChannel(o =>
{
    o.MaxRetryAttempts = 4;
}).AddStandardResilienceHandler();

builder.Services.AddOpenTelemetry()
    .WithMetrics(x =>
    {
        x.AddPrometheusExporter();
        x.AddMeter("Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSerilogRequestLogging();
app.MapPrometheusScrapingEndpoint();
app.MapAuthenticationEndpoints();
app.MapTicketEndpoints();

app.Run();