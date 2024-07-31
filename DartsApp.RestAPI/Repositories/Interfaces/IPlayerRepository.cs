using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Repositories.Interfaces
{
    public interface IPlayerRepository: IBaseRepository<Player>
    {

        Task<Player> PlayerWithHighestRankingPlace();
        Task<IEnumerable<Player>> PlayerWithoutRankingPoints();
    }
}
