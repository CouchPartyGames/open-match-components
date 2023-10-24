
public static class MatchFactory
{
    public static Match CreateMatch(string matchFunction, string profile)
    {
        return new Match
        {
            MatchId = "",
            MatchFunction = matchFunction,
            MatchProfile = profile
        };
    }    
}
