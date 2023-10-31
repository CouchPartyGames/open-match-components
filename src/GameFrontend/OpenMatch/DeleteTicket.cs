namespace GameFrontend.OpenMatch;

using OpenMatch;

public sealed class DeleteTicket
{
    private FrontendService.FrontendServiceClient _client;

    public DeleteTicket(GrpcClientFactory factory)
    {
        _client = factory.CreateClient<FrontendService.FrontendServiceClient>(Constants.OpenMatchFrontend);
    }
    
    public sealed class RequestBuilder
    {
        private DeleteTicketRequest _request = new();

        public RequestBuilder WithTicketId(TicketId id)
        {
            _request.TicketId = id.Value;
            return this;
        }
        
        public DeleteTicketRequest Build()
        {
            return _request;
        }
    }

    public sealed record TicketId(string Value);
}