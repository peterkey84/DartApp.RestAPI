using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IPlayerTournamentService: IBaseService<PlayerTournamentDto, PlayerTournament>
    {
        string GetPlayerStatisticsByPlayerId(int id);

    }
}
