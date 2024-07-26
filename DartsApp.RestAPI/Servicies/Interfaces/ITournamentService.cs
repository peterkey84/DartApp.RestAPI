using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface ITournamentService: IService<TournamentCreateDto, Tournament>
    {
    }
}
