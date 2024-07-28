using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class TournamentService : BaseService<TournamentCreateDto, Tournament>, ITournamentService
    {
        public TournamentService(IBaseRepository<Tournament> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
