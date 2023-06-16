namespace MatchFunction.Services;

using OpenMatch;
public class MatchFunctionRunService : MatchFunction.MatchFunctionBase
{
    public override async Task Run(RunRequest request, IServerStreamWriter<RunResponse> responseStream, ServerCallContext context) {

        var response = new RunResponse();

        await responseStream.WriteAsync(response);
    }
}
