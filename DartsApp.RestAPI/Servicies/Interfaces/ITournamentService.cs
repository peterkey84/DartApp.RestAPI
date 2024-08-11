using DartsApp.RestAPI.DTOs.TournamentDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface ITournamentService: IBaseService<TournamentCreateDto, Tournament>
    {
        Task<IEnumerable<TournamentViewDto>> GetAllAsync();

        new Task<IEnumerable<TournamentMatchedDto>> GetMatchedCities(string city);

    }
}
