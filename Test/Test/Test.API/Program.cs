using Microsoft.EntityFrameworkCore;
using Test.API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string connectionString = builder.Configuration.GetConnectionString("db") ?? throw new ArgumentNullException(nameof(connectionString));
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TrainingDbContext>(opt => opt.UseSqlServer("name=ConnectionStrings:db"));
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
