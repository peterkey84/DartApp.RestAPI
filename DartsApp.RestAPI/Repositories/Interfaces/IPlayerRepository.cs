using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Repositories.Interfaces
{
    public interface IPlayerRepository: IBaseRepository<Player>
    {

        Task<Player> PlayerWithHighestRankingPlace();
        Task<IEnumerable<Player>> PlayerWithoutRankingPoints();
        Task<IEnumerable<Player>> GetPlayersWithRankingPointsUnder200();
        string GetPlayerStatisticsByPlayerId(int id);
        int GetTournamentIdByPlayerId(int id);
        Task AddPlayerTournamnetAsync(PlayerTournament playerTournament);
        Task<PlayerTournament> GetPlayerTournament(int playerId);


    }
}
