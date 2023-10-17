using MatchFunction.Services;
using MatchFunction.Configurations;

//var builder = WebApplication.CreateSlimBuilder(args);	 // .net 8 + AOT
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGrpcService()
    .AddHealthChecksService() 
    .AddSwaggerService();


var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.MapGrpcReflectionService();
    app.UseSwagger();
	app.UseSwaggerUI(c => {
    	c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchFunction V1");
	});
}


// Services
app.MapGrpcService<MatchFunctionRunService>();
app.MapGrpcHealthChecksService();

app.Run();
