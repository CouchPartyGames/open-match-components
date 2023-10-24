namespace MatchFunction.Services;

using OpenMatch;
using MatchFunction.OM.Responses;

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
		var matches = GetMatches();
		
		foreach (var match in matches) {
				// Respond with Proposals
	        var response = new RunResponseBuilder()
		        .WithMatch(match)
		        .Build();

	        await responseStream.WriteAsync(response);
        }
    }

    public List<Match> GetMatches()
    {
	    return new List<Match> {
			new Match
			{
				MatchFunction = "test",
				MatchId = "test"
			}
	    };
    }
}
