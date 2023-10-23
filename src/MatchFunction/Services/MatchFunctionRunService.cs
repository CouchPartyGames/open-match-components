using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MatchFunction.Services;

using OpenMatch;

public class MatchFunctionRunService : MatchFunction.MatchFunctionBase {

    public override async Task Run(RunRequest request, IServerStreamWriter<RunResponse> responseStream, ServerCallContext context)
    {

	    /*
	    request.Profile.Name;
	    request.Profile.Pools;
	    request.Profile.Extensions;
	    */
	    
		RepeatedField<Pool> pools = new();


		var matches = GetMatches();
		foreach (var match in matches) {
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

public class RunResponseBuilder
{
	private Match match = new();

	public RunResponseBuilder WithMatch(Match match) {
		this.match = match;
		return this;
	}

	public RunResponse Build()
	{
		return new RunResponse
		{
			Proposal = match
		};
	}
}