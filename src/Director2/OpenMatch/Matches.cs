namespace Director2.OpenMatch;

public class Matches
{
    public bool Fetch(BackendService.BackendServiceClient client, FetchMatchesRequest request)
    {
        var response = client.FetchMatches(request);
        return true;
    }

    public class RequestBuilder
    {
        private MatchProfile _profile = new();
        private FunctionConfig _config = new();

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