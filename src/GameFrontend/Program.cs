using GameFrontend.OpenMatch;
using Microsoft.Extensions.Http.Resilience;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcClient<FrontendService.FrontendServiceClient>(Constants.OpenMatchFrontend, o => 
{
    //Configuration["OPENMATCH_FRONTEND_HOST"]
    var address = "https://open-match-frontend.open-match.svc.cluster.local:50503";
    o.Address = new Uri(address);
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


app.MapPrometheusScrapingEndpoint();

app.MapPost("/v1/tickets", () => "hello");
app.MapGet("/v1/tickets/{id}", () => "hello");
app.MapDelete("/v1/tickets/{id}", () => "hello");

app.Run();
