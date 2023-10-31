namespace GameFrontend.OpenMatch;

public sealed class CreateTicket
{
    private FrontendService.FrontendServiceClient _client;

    public CreateTicket(GrpcClientFactory factory)
    {
        _client = factory.CreateClient<FrontendService.FrontendServiceClient>(Constants.OpenMatchFrontend);
    }
    
    public sealed class RequestBuilder
    {
        private CreateTicketRequest _request = new CreateTicketRequest();
        
        public RequestBuilder WithTicket(Ticket ticket)
        {
            _request.Ticket = ticket;
            return this;
        }
        
        public CreateTicketRequest Build()
        {
            return _request;
        }
    }
}