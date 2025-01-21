using KutuphaneYonetimSistemi.Models;
using KutuphaneYonetimSistemi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDB yap�land�rmas�n� `DatabaseSettings` s�n�f�na ba�la
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("MongoDB"));

// `DatabaseSettings`'i ba��ml�l�k olarak ekle
builder.Services.AddSingleton<DatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

// MongoDB istemcisini (client) ekle
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetValue<string>("MongoDB:ConnectionString")));

// Kitap servisini ekle
builder.Services.AddSingleton<KitapService>();

// Controller'lar� ekle
builder.Services.AddControllers();

// Swagger (API dok�mantasyonu) yap�land�rmas�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger'� etkinle�tir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
