namespace MatchFunction.OM;

    // https://openmatch.dev/site/docs/reference/api/#searchfields
public sealed record TagField(string Value);

    // https://openmatch.dev/site/docs/reference/api/#searchfieldsstringargsentry
public sealed record KeyValueField(string Key, string Value);

    // https://openmatch.dev/site/docs/reference/api/#searchfieldsdoubleargsentry
public sealed record DoubleField(string Key, double Value);


public sealed class CreateTicket
{

    public sealed class RequestBuilder
    {
        public RequestBuilder WithSearchFields()
        {
            return this;
        }

        public RequestBuilder WithExtensions()
        {
            return this;
        }

        public RequestBuilder WithPersistence()
        {
            return this;
        }

        public CreateTicketRequest Build()
        {
            return new CreateTicketRequest();
        }
    }
}