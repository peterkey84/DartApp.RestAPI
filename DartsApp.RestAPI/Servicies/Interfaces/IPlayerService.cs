using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IPlayerService: IBaseService<PlayerCreateDto, Player>
    {
        new Task<IEnumerable<PlayerViewDto>> GetAllAsync();
        Task<PlayerRankingDto> GetPlayerWithHighestRankingPlace();
        Task<IEnumerable<PlayerRankingDto>> GetPlayersWithoutRankingPoints();
    }
}
