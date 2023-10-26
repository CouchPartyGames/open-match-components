using Director2.OpenMatch;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var backendEndpoint = "open-match-backend.open-match.svc.cluster.local:50505";
var matchFunctionEndpoint = "mm102-tutorial-matchfunction.mm102-tutorial.svc.cluster.local";
var allocationEndpoint = "localhost:5322";

    // Connect to Allocation Service
using var allocateChannel = GrpcChannel.ForAddress(allocationEndpoint);

    // Connect to Backend Service
var options = new GrpcChannelOptions();
using var channel = GrpcChannel.ForAddress(backendEndpoint, options);
var backendClient = new BackendService.BackendServiceClient(channel);

    // Create Profiles
var fetcher = new Matches();
var builder = new Profiles();
var profiles = builder.GenerateProfiles();


foreach (var profile in profiles)
{ 
        // Fetch Matches
    /*
    request = new Fetch.RequestBuilder()
        .WithMatchProfile(profile)
        //.WithFunctionConfig()
        .Build();
    
    var fetch = new Fetch();
    fetch.FetchTickets(backendClient, request);
    */

        // Allocation
        /*
    var request = new Allocation.RequestBuilder()
        .WithNamespace("default")
        .WithMetadata()
        .WithGameSelectors()
        .WithMultiCluster().Build();
        
    var allocate = new Allocations();
    allocate.AllocateGameServer(allocateClient, request);
        */
    
        // Assignment
        /*
    var request = new Assign.RequestBuilder()
        .WithAssignmentGroup()
        .Build();

    var assign = new Assign();
    assign.AssignTickets(backendClient, request);
    */
}



