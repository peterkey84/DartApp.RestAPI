using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Repositories.Interfaces
{
    public interface ITournamentRepository: IBaseRepository<Tournament>
    {
        Task<IEnumerable<Tournament>> GetMatchedCities(string city);
    }
}
