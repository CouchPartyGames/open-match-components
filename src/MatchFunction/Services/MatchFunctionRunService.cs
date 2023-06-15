namespace MatchFunction.Services;

public class MatchFunctionRunService : OpenMatch.MatchFunction.MatchFunctionBase
{
    public override async Task Run(RunRequest request, IServerStreamWriter<RunResponse> responseStream, ServerCallContext context) {
        /*
        var response = new RunResponse()
        {
            Proposal = Match { }
        }
        await responseStream.WriteAsync(response);*/
    }
}
