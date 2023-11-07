namespace GameFrontend.OpenMatch;

using OpenMatch;

public sealed class DeleteTicket
{
    private FrontendService.FrontendServiceClient _client;

    public DeleteTicket(GrpcClientFactory factory)
    {
        _client = factory.CreateClient<FrontendService.FrontendServiceClient>(Constants.OpenMatchFrontend);
    }

    public async Task<bool> Delete(TicketId ticketId)
    {
        var request = new RequestBuilder()
            .WithTicketId(ticketId)
            .Build();
        var metadata = new Metadata()
        {
            { "STuff", "stuff"}
        };
        var response = await _client.DeleteTicketAsync(request, metadata);
        return true;
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