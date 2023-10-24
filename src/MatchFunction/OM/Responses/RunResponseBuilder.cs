namespace MatchFunction.OM.Responses;

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
