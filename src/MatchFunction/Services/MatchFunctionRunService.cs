namespace MatchFunction.Services;

using OpenMatch;
public class MatchFunctionRunService : MatchFunction.MatchFunctionBase
{
    public override async Task Run(RunRequest request, IServerStreamWriter<RunResponse> responseStream, ServerCallContext context) {

        var match = new Match();
        match.MatchFunction = "test";
        match.MatchId = "test";

        var response = new RunResponse();
        response.Proposal = match;

        await responseStream.WriteAsync(response);
    }
}
