using OnlineDersPlatformuApi.Models;
using OnlineDersPlatformuApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ( MongoDb Ayarlarý)
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<InstructorService>();
builder.Services.AddSingleton<StudentService>();
builder.Services.AddSingleton<CourseService>();
builder.Services.AddSingleton<CourseContentService>();
builder.Services.AddSingleton<ExamService>();
builder.Services.AddSingleton<ExamResultService>();


// Learn more about configuring Swagger/OpenAPI at
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
