using DartsApp.RestAPI.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Repositories.Infrastructure;
using DartsApp.RestAPI.Servicies.Infrastructure;
using DartsApp.RestAPI.Servicies.Interfaces;
using DartsApp.RestAPI.Extensions;
using DartsApp.RestAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);


//Added AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Added connetion string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDependencyInjection();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.AddConsole(); 
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
