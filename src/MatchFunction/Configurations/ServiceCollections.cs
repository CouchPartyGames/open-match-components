namespace MatchFunction.Configurations;

public static class ServiceCollections
{
    public static IServiceCollection AddGrpcService(this IServiceCollection services)
    {
        //services.AddGrpc()
        services.AddGrpc().AddJsonTranscoding();
        services.AddGrpcReflection();

        return services;
    }

    public static IServiceCollection AddHealthChecksService(this IServiceCollection services)
    {
        services.AddGrpcHealthChecks()
            .AddCheck("Sample", () => HealthCheckResult.Healthy());

        return services;
    }

    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        
        services.AddGrpcSwagger();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo { 
                    Title = "MatchFunction", 
                    Version = "v1" 
                });

            //var filePath = Path.Combine(System.AppContext.BaseDirectory, "Server.xml");
            //c.IncludeXmlComments(filePath);
            //c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
        }); 

        return services;
    }
}
