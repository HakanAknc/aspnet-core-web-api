var builder = WebApplication.CreateBuilder(args);

// Services (Contianer)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Uygulamaya swagger kullanması gerektiğini söylüyoruz aşağdaki işlemlerle.

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
