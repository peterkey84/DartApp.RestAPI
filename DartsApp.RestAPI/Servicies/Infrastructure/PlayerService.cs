using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class PlayerService : Service<PlayerCreateDto, Player>, IPlayerService
    {
        public PlayerService(IRepository<Player> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
