using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddCustomSwaggerGen();

// log4net
// nuget: log4net
//        Microsoft.Extensions.Logging.Log4Net.AspNetCore
builder.Logging.AddLog4Net("Config/log4net.Config");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
