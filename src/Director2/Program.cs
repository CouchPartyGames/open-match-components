using Agones;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var backendEndpoint = "open-match-backend.open-match.svc.cluster.local:50505";
var matchFunctionEndpoint = "mm102-tutorial-matchfunction.mm102-tutorial.svc.cluster.local";
var allocationEndpoint = "localhost:5322";


    // Connect to Allocation Service
using var allocateChannel = GrpcChannel.ForAddress(allocationEndpoint);
var agonesSdk = new SDK.SDKClient(allocateChannel);
var agones = new AgonesSDK(15, agonesSdk);
var connected = agones.ConnectAsync();
var response = await agones.AllocateAsync();

    // Connect to Backend Service
using var channel = GrpcChannel.ForAddress(backendEndpoint);
var backendClient = new BackendService.BackendServiceClient(channel);

//var profiles = ProfileList();

    // Allocation

    // Assign
var request = new AssignTicketsRequest();
var reponse = await backendClient.AssignTicketsAsync(request);


public class GenerateProfiles
{
    private List<string> Modes = new List<string>() { "mode.demo", "mode.ctf", "mode.battleroyale" };

    /*
    public Pool CreatePool()
    {
        return new Pool
        {
            Name = "pool",
            TagPresentFilters =
            {
                "Tag"
            }
        }
    }

    public MatchProfile CreateProfile()
    {
       return new MatchProfile
       {
           Name = "test",
           Pools = new RepeatedField<Pool>()
           {
               
           }
       } 
    }*/
}


