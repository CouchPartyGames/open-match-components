namespace GameFrontend.Endpoints;

using GameFrontend.OpenMatch;

public static class TicketEndpoints
{
    public static void MapTicketEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/tickets", CreateTicket);
        app.MapGet("/v1/tickets/{id}", GetTicket);
        app.MapDelete("/v1/tickets/{id}", DeleteTicket);
    }

    static async Task<Results<Ok, NotFound>> CreateTicket()
    {
        var ticket = new CreateTicket.CreateTicketBuilder()
            .AddDouble(new CreateTicket.DoubleEntry("latency", 32.0))
            .AddDouble(new CreateTicket.DoubleEntry("skill", 3.0))
            .AddString(new CreateTicket.StringEntry("game", "32432"))
            .Build();

        var request = new CreateTicket.RequestBuilder()
            .WithTicket(ticket)
            .Build();

        return TypedResults.Ok();
    }

    static async Task<Results<Ok, NotFound>> GetTicket()
    {
        return TypedResults.Ok();
    }

    static async Task<Results<Ok, NotFound>> DeleteTicket()
    {
        return TypedResults.Ok();
    }
}