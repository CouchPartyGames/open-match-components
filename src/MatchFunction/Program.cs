using MatchFunction.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });

    //var filePath = Path.Combine(System.AppContext.BaseDirectory, "Server.xml");
    //c.IncludeXmlComments(filePath);
    //c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});
builder.Services.AddGrpcHealthChecks()
                .AddCheck("Sample", () => HealthCheckResult.Healthy());




var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
	app.UseSwaggerUI(c => {
    	c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchFunction V1");
	});
}


// Configure the HTTP request pipeline.
app.MapGrpcReflectionService();
app.MapGrpcService<GreeterService>();
app.MapGrpcHealthChecksService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
