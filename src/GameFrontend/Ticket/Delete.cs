namespace MatchFunction.OM;

public class Delete
{

    public sealed class RequestBuilder
    {
        private string _ticketId = String.Empty;
        
        public RequestBuilder WithTicketId(string ticketId)
        {
            _ticketId = ticketId;
            return this;
        }
        public DeleteTicketRequest Build()
        {
            return new DeleteTicketRequest
            {
                TicketId = _ticketId
            };
        }
    }
}