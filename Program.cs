using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory data (instead of a database)
var dealers = new List<Dealer>
{
    new Dealer { Id = 1, Name = "ABC Motors", Location = "Dallas" },
    new Dealer { Id = 2, Name = "Speedy Cars", Location = "Austin" }
};

app.MapGet("/", () => "Car Dealer API is running!");

// GET: /dealers - list all dealers
app.MapGet("/dealers", () => dealers);

// GET: /dealers/{id} - get one dealer
app.MapGet("/dealers/{id}", (int id) =>
{
    var dealer = dealers.Find(d => d.Id == id);
    return dealer is not null ? Results.Ok(dealer) : Results.NotFound();
});

// POST: /dealers - add a new dealer
app.MapPost("/dealers", (Dealer newDealer) =>
{
    newDealer.Id = dealers.Count + 1;
    dealers.Add(newDealer);
    return Results.Created($"/dealers/{newDealer.Id}", newDealer);
});

app.Run();

record Dealer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Location { get; set; } = "";
}
