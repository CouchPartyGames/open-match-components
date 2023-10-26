namespace Director2.OpenMatch;

public class Fetch
{
    public bool FetchTickets(BackendService.BackendServiceClient client, FetchMatchesRequest request)
    {
        var response = client.FetchMatches(request);
        return true;
    }

    public class RequestBuilder
    {
        private MatchProfile _profile;
        private FunctionConfig _config;

        public RequestBuilder WithMatchProfile(MatchProfile profile)
        {
             _profile = profile;
             return this;
        }

        public RequestBuilder WithFunctionConfig(FunctionConfig config)
        {
            _config = config;
            return this;
        }
        
        public FetchMatchesRequest Build()
        {
                // https://openmatch.dev/site/docs/reference/api/#fetchmatchesrequest
            return new FetchMatchesRequest
            {
                Config = _config, 
                Profile = _profile
            };
        }
    }
}