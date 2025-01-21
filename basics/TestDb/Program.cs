using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDB ba�lant�s�n� DI container'a ekleyin
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb");
    return new MongoClient(connectionString);
});

// MongoDB Database'i DI container'a ekleyin
builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("IlkTestMongo");
});

// Swagger'� ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Swagger'� geli�tirme ortam�nda kullanabilmek i�in
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
