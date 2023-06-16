using Director.Services;
using Google.Api;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();
builder.Services.AddGrpcHealthChecks()
    .AddCheck("Sample", () => HealthCheckResult.Healthy());
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
            Version = "v1",
            Title = "OpenMatch - Director API",
            Description = "Requests Open Match for matches and then sets Assignments",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Contact",
                Url = new Uri("https://github.com/CouchPartyGames/open-match-components/issues/new")
            },
            License = new OpenApiLicense
            {
                Name = "License",
                Url = new Uri("https://github.com/CouchPartyGames/open-match-components/blob/main/LICENSE")
            }
    });

    //var filePath = Path.Combine(System.AppContext.BaseDirectory, "Server.xml");
    //c.IncludeXmlComments(filePath);
    //c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Director v1");
    });
}

app.MapGrpcService<GreeterService>();
app.MapGrpcHealthChecksService();

app.Run();
