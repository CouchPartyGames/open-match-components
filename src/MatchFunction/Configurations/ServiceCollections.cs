﻿namespace MatchFunction.Configurations;

public static class ServiceCollections {

    public static IServiceCollection AddGrpcService(this IServiceCollection services) {
        services.AddGrpc(o =>
        {
            o.EnableDetailedErrors = true;
        }).AddJsonTranscoding();
        //services.AddGrpcReflection();

        return services;
    }

    public static IServiceCollection AddHealthChecksService(this IServiceCollection services) {
        services.AddGrpcHealthChecks()
            .AddCheck("Sample", () => HealthCheckResult.Healthy());

        return services;
    }

    public static IServiceCollection AddSwaggerService(this IServiceCollection services) {
        services.AddGrpcSwagger();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1",
                new OpenApiInfo { 
                    Version = "v1",
                    Title = "OpenMatch - MatchFunction API",
                    Description = "Core matchmaking logic implemented as a services",
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

        return services;
    }
}
