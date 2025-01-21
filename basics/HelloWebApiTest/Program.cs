var builder = WebApplication.CreateBuilder(args);

// Services (Contianer)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Uygulamaya swagger kullanmasý gerektiðini söylüyoruz aþaðdaki iþlemlerle.

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
