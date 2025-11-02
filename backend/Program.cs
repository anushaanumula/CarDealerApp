using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()      // allow requests from any origin
              .AllowAnyMethod()      // allow GET, POST, PUT, DELETE
              .AllowAnyHeader();     // allow headers
    });
});

var app = builder.Build();

// Enable CORS
app.UseCors();

// In-memory data
var cars = new List<Car>
{
    new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020 },
    new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2021 }
};

// GET all cars
app.MapGet("/cars", () => cars);

// GET one car by ID
app.MapGet("/cars/{id}", (int id) =>
{
    var car = cars.FirstOrDefault(c => c.Id == id);
    return car is not null ? Results.Ok(car) : Results.NotFound();
});

// POST - add new car
app.MapPost("/cars", (Car newCar) =>
{
    newCar.Id = cars.Max(c => c.Id) + 1;
    cars.Add(newCar);
    return Results.Created($"/cars/{newCar.Id}", newCar);
});

// PUT - update a car
app.MapPut("/cars/{id}", (int id, Car updatedCar) =>
{
    var car = cars.FirstOrDefault(c => c.Id == id);
    if (car is null) return Results.NotFound();
    car.Make = updatedCar.Make;
    car.Model = updatedCar.Model;
    car.Year = updatedCar.Year;
    return Results.Ok(car);
});

// DELETE - remove car
app.MapDelete("/cars/{id}", (int id) =>
{
    var car = cars.FirstOrDefault(c => c.Id == id);
    if (car is null) return Results.NotFound();
    cars.Remove(car);
    return Results.Ok();
});

app.Run();

// Car record
record Car
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}
