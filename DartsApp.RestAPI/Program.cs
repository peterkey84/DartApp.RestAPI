using DartsApp.RestAPI.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Repositories.Infrastructure;
using DartsApp.RestAPI.Servicies.Infrastructure;
using DartsApp.RestAPI.Servicies.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//Added AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Added connetion string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Added repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();

//Added services

builder.Services.AddScoped(typeof(IService<,>), typeof(Service<,>));

builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();


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
