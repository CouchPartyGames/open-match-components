using GameFrontend.OpenMatch;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Http.Resilience;
using OpenTelemetry.Metrics;
using Serilog;
using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new CompactJsonFormatter())
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

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

app.MapPost("/v1/tickets", CreateTicket);
app.MapGet("/v1/tickets/{id}", GetTicket);
app.MapDelete("/v1/tickets/{id}", DeleteTicket);

app.Run();


static async Task<Results<Ok, NotFound>> CreateTicket()
{
    var ticket = new CreateTicket.CreateTicketBuilder()
        .AddDouble(new CreateTicket.DoubleEntry("latency", 32.0))
        .AddDouble(new CreateTicket.DoubleEntry("skill", 3.0))
        .AddString(new CreateTicket.StringEntry("game", "32432"))
        .Build();
    
    var request = new CreateTicket.RequestBuilder()
        .WithTicket(ticket)
        .Build();
    
    return TypedResults.Ok();
}

static async Task<Results<Ok, NotFound>> GetTicket()
{
    return TypedResults.Ok();
}

static async Task<Results<Ok, NotFound>> DeleteTicket()
{
    return TypedResults.Ok();
}

