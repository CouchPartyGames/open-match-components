using MatchFunction.Services;
using MatchFunction.Configurations;
using OpenMatch;

var builder = WebApplication.CreateSlimBuilder(args);	 // .net 8 + AOT supported
//var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGrpcService()
    .AddHealthChecksService() 
    .AddSwaggerService();

builder.Services.AddGrpcClient<QueryService.QueryServiceClient>(o =>
{
	var host = builder.Configuration["QUERY_HOST"] ?? "https://open-match-query.open-match.svc.cluster.local:50503";
	o.Address = new Uri(host);
});
	//.AddStandardResilienceHandler();


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
