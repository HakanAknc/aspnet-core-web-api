var builder = WebApplication.CreateBuilder(args);

// Services (Contianer)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Uygulamaya swagger kullanmas� gerekti�ini s�yl�yoruz a�a�daki i�lemlerle.

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
