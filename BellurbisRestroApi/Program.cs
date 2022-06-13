using Microsoft.EntityFrameworkCore;
using BellurbisRestroApi.Models;
using BellurbisRestroApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskContaxt>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));
builder.Services.AddScoped<RAPRepository, RAPRepository > ();




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
