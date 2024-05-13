using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConnectionString connection = builder.Configuration.GetSection("ConnectionString").Get<ConnectionString>();
Global.ApiConnetion = connection.ApiConnetion;

builder.Services.AddDbContext<CapitalDb>(options => options.UseSqlServer(Global.ApiConnetion));

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
   
