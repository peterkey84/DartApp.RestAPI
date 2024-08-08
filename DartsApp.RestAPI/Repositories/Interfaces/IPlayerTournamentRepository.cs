using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Repositories.Interfaces
{
    public interface IPlayerTournamentRepository: IBaseRepository<PlayerTournament>
    {

        string GetPlayerStatisticsByPlayerId(int id);
    }
}
