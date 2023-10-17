namespace MatchFunction.Configuration;


public static class DependencyInjection {

	public static IServiceCollection AddConfigureServices(this IServiceCollection services) {
		
		services.AddGrpc().AddJsonTranscoding();
		services.AddGrpcReflection();
		services.AddGrpcSwagger();
		services.AddSwaggerGen(c => {
			c.SwaggerDoc("v1",
				new OpenApiInfo { Title = "OpenMatch MatchFunction", Version = "v1" });

			//var filePath = Path.Combine(System.AppContext.BaseDirectory, "Server.xml");
			//c.IncludeXmlComments(filePath);
			//c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
		});
		services.AddGrpcHealthChecks()
        	.AddCheck("Sample", () => HealthCheckResult.Healthy());

		return services;
	}

}
