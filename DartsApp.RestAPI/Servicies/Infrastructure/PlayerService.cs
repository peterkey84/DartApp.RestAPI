using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class PlayerService : BaseService<PlayerCreateDto, Player>, IPlayerService
    {
        public PlayerService(IBaseRepository<Player> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
