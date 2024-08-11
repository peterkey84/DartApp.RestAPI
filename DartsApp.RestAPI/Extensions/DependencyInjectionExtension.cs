using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Infrastructure;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Infrastructure;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DartsApp.RestAPI.Extensions
{
    public static class DependencyInjectionExtension
    {

        public static void AddDependencyInjection(this IServiceCollection service)
        {

            //Added repositories
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            service.AddScoped<IBaseRepository<Board>, BoardRepository>();
            service.AddScoped<IBoardRepository, BoardRepository>();
            service.AddScoped<IBaseRepository<Place>, PlaceRepository>();
            service.AddScoped<IPlaceRepository, PlaceRepository>();
            service.AddScoped<IBaseRepository<Player>, PlayerRepository>();
            service.AddScoped<IPlayerRepository, PlayerRepository>();
            service.AddScoped<IBaseRepository<Tournament>, TournamentRepository>();
            service.AddScoped<ITournamentRepository, TournamentRepository>();

            //Added services

            service.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

            service.AddScoped<IBoardService, BoardService>();
            service.AddScoped<IPlaceService, PlaceService>();
            service.AddScoped<IPlayerService, PlayerService>();
            service.AddScoped<ITournamentService, TournamentService>();
        }
    }
}
