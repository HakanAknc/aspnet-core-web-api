using CarRentalApi.DataAccess;
using CarRentalApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  // MongoDb baðlantýsý kuruldu
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

// Services baðlantýlarý
builder.Services.AddSingleton<CarRepository>();
builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<ReservationRepository>();
builder.Services.AddSingleton<PricingRepository>();
builder.Services.AddSingleton<UserRepository>();

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
