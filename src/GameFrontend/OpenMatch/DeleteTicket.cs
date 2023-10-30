using MatchFunction.OM;

namespace GameFrontend.OpenMatch;

public sealed class DeleteTicket
{
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