using DartsApp.RestAPI.DTOs.TournamentDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface ITournamentService: IBaseService<Tournament>
    {

        Task<IEnumerable<TournamentViewDto>> GetAllTournamentsAsync();
        Task<TournamentViewDto> GetTournamentByIdAsync(int id);
        Task<TournamentCreateDto> AddTournamentAsync(TournamentCreateDto tournament);
        Task<TournamentCreateDto> UpdateTournamentAsync(TournamentCreateDto tournament);
        new Task<IEnumerable<TournamentMatchedDto>> GetMatchedCities(string city);

    }
}
