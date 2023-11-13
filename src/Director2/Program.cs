using Director2.OpenMatch;
using Director2.Agones;
using Director2.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<HostOptions>(o =>
        {
            o.ShutdownTimeout = TimeSpan.FromSeconds(15);
            o.ServicesStartConcurrently = true;
            o.ServicesStopConcurrently = true;
        });
        
        services.AddGrpcClient<QueryService.QueryServiceClient>("OpenMatchQuery", o =>
        {
            var address = context.Configuration["OPENMATCH_QUERY_HOST"] ??
                          "https://open-match-query.open-match.svc.cluster.local:50503";
            o.Address = new Uri(address);
        }).AddStandardResilienceHandler();

        services.AddGrpcClient<BackendService.BackendServiceClient>("OpenMatchBackend", o =>
        {
            var address = context.Configuration["OPENMATCH_BACKEND_HOST"] ??
                          "https://open-match-backend.open-match.svc.cluster.local:50505";
            o.Address = new Uri(address);
        }).AddStandardResilienceHandler();

        services.AddHostedService<DirectorService>();

    })
    .Build();


await host.RunAsync();

var allocationEndpoint = "localhost:5322";

var matchFunctionHost = "mm102-tutorial-matchfunction.mm102-tutorial.svc.cluster.local";
var matchFunctionPort = 5555;
var matchFunctionGrpc = true;

    // Connect to Allocation Service
//using var allocateChannel = GrpcChannel.ForAddress(allocationEndpoint);


    // Create Profiles
//var fetcher = new FetchMatches();

var modes = new DefaultModes();

var builder = new Profiles(modes);
var profiles = builder.GenerateProfiles();


foreach (var profile in profiles)
{ 
    Console.WriteLine(profile);
    
        // Fetch Matches
    var funcConfig = FetchMatches.CreateFunctionConfig(matchFunctionHost, matchFunctionPort, matchFunctionGrpc);
    
    var fetchRequest = new FetchMatches.RequestBuilder()
        .WithMatchProfile(profile)
        .WithFunctionConfig(funcConfig)
        .Build();
    
    //fetch.FetchTickets(backendClient, request);

        // Allocation
    /*
    var request = new ServerAllocations.RequestBuilder()
        .WithNamespace("default")
        .WithMetadata()
        .WithGameSelectors()
        .WithMultiCluster()
        .Build();
        */
        
    /*
    var allocate = new Allocations();
    allocate.AllocateGameServer(allocateClient, request);
        */
    
        // Assignment
    /*var assignRequest = new Assign.RequestBuilder()
        .WithAssignmentGroup()
        .Build();*/

    //var assign = new Assign();
    //assign.AssignTickets(backendClient, request);
    
}
