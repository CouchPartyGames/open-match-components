namespace MatchFunction.Services;

using OpenMatch;
using MatchFunction.OM;

public class MatchFunctionRunService : MatchFunction.MatchFunctionBase {

    public override async Task Run(RunRequest request, IServerStreamWriter<RunResponse> responseStream, ServerCallContext context)
    {
	    /*
	    request.Profile.Name;
	    request.Profile.Pools;
	    request.Profile.Extensions;
	    */
	    
		RepeatedField<Pool> pools = new();


			// Get Proposals (matches)
		var matches = GetMatches(request.Profile);
		
		foreach (var match in matches) {
				// Respond with Proposals
	        var response = new Matches.ResponseBuilder()
		        .WithMatch(match)
		        .Build();

	        await responseStream.WriteAsync(response);
        }
    }

    // https://openmatch.dev/site/docs/reference/api/#openmatch-MatchProfile
    public List<Match> GetMatches(MatchProfile profile)
    {
	    //profile.Extensions;
	    //profile.Pools;
	    
	    string matchId = "test";
	    string matchFunction = "test";
	    string profileName = profile.Name;
	    
	    var match = new Matches.MatchBuilder()
		    .WithId(matchId)
		    .WithFunctionName(matchFunction)
		    .WithProfileName(profileName)
		    //.AddTicket()
		    //.AddExtension()
		    .Build();
	    
	    return new List<Match> {
		    match
	    };
    }
}