using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDB baðlantýsýný DI container'a ekleyin
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

// Swagger'ý ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Swagger'ý geliþtirme ortamýnda kullanabilmek için
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
