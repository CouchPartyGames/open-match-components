using MatchFunction.Services;
using MatchFunction.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGrpcService()
    .AddHealthChecksService() 
    .AddSwaggerService();     //triggers Unhandled exception. System.InvalidOperationException: Error binding gRPC service 'MatchFunctionRunService'


var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.MapGrpcReflectionService();
    app.UseSwagger();
	app.UseSwaggerUI(c => {
    	c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchFunction V1");
	});
}


// Configure the HTTP request pipeline.
//app.MapGrpcReflectionService();

// Services
app.MapGrpcService<MatchFunctionRunService>();
app.MapGrpcHealthChecksService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
