using DartsApp.RestAPI.DTOs.PlayerDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IPlayerService: IBaseService<Player>
    {
        Task<IEnumerable<PlayerViewDto>> GetAllPlayersAsync();
        Task<PlayerViewDto> GetPlayerByIdAsync(int id);
        Task<PlayerCreateDto> AddPlayerAsync(PlayerCreateDto playerDto);
        Task<PlayerCreateDto> UpdatePlayerAsync(PlayerCreateDto playerDto);
        Task<PlayerRankingDto> GetPlayerWithHighestRankingPlace();
        Task<IEnumerable<PlayerRankingDto>> GetPlayersWithoutRankingPoints();
        Task<IEnumerable<PlayerRankingDto>> GetPlayersWithRankingPointsUnder200();
        string GetPlayerStatisticsByPlayerId(int id);


    }
}
