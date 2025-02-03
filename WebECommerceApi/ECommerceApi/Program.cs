using ECommerceApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ECommerceApi.Repositories;
using ECommerceApi.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDB yapýlandýrmasýný yükle
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

// User
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddScoped<UserService>();

// Product
builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddScoped<ProductService>();

// Category
builder.Services.AddSingleton<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

// Order
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddScoped<OrderService>();

// Inventory
builder.Services.AddSingleton<InventoryRepository>();
builder.Services.AddScoped<InventoryService>();

// Wallet
builder.Services.AddSingleton<WalletRepository>();
builder.Services.AddScoped<WalletService>();


// Kontrolleri ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
