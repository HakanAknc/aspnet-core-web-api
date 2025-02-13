using CarRentalApi.Models;
using CarRentalApi.Repositories;
using CarRentalApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

// Servisler
builder.Services.AddSingleton<CarRepository>();
builder.Services.AddSingleton<CarService>();

builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<CustomerService>();

builder.Services.AddSingleton<ReservationRepository>();
builder.Services.AddSingleton<ReservationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
