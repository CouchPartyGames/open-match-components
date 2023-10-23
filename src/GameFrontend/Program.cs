var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/v1/tickets", () => "hello");
app.MapGet("/v1/tickets/{id}", () => "hello");
app.MapDelete("/v1/tickets/{id}", () => "hello");

app.Run();


public class Data
{
    public string FrontendAddress { get; set; } = "";

    public async void Create() {
 
        using var channel = GrpcChannel.ForAddress(FrontendAddress);
        var frontendClient = new OpenMatch.FrontendService.FrontendServiceClient(channel);

        // Create Ticket
        var ticket = new Ticket();
        //ticket.Extensions.Values = new Google.Protobuf.Collections.MapField<string, Google.Protobuf.WellKnownTypes.Any>();
        //ticket.SearchFields;

        // Create
        var createRequest = new CreateTicketRequest();
        createRequest.Ticket = ticket;
        await frontendClient.CreateTicketAsync(createRequest);

            // Delete
        var deleteRequest = new DeleteTicketRequest();
        deleteRequest.TicketId = "myticket";
        await frontendClient.DeleteTicketAsync(deleteRequest);
    }
}


public record CreateTicketCommand() {

}

public record GetTicketRequest(Guid Id) {

}

public record DeleteTicketCommand(Guid Id) {

}
