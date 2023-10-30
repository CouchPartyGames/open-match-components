using MatchFunction.OM;

namespace GameFrontend.OpenMatch;

public sealed class CreateTicket
{
    
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