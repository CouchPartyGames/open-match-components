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


