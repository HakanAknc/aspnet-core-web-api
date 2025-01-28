using ECommerceApi.Models;
using ECommerceApi.Services;
using Microsoft.Extensions.Options;
using ECommerceApi.Repositories;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// MongoDB ayarlarýný yapýlandýr
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

// Product repository ve service kayýtlarý
builder.Services.AddSingleton<IRepository<Product>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoRepository<Product>(database, settings.ProductsCollection);
});

builder.Services.AddScoped<ProductService>();

// User repository'yi kayýt et
builder.Services.AddSingleton<IRepository<User>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoRepository<User>(database, settings.UsersCollection);
});

// User service'i kayýt et
builder.Services.AddScoped<UserService>();

// Product repository ve service kayýtlarý
builder.Services.AddSingleton<IRepository<Product>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoRepository<Product>(database, settings.ProductsCollection);
});

builder.Services.AddScoped<ProductService>();

//builder.Services.AddSingleton<IRepository<Cart>>(sp =>
//{
//    var database = sp.GetRequiredService<IMongoDatabase>();
//    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
//    return new MongoRepository<Cart>(database, settings.CartsCollection);
//});

//builder.Services.AddScoped<CartService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
