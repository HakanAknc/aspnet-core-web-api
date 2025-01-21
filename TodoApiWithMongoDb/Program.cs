using Microsoft.Extensions.Options;
using TodoApiWithMongoDb.Models;
using TodoApiWithMongoDb.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDB ayarlar�n� DI (Dependency Injection) container'a ekle
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// MongoDB i�in TodoService'i ekle
builder.Services.AddSingleton<TodoService>();

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI yap�land�rmas�
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
