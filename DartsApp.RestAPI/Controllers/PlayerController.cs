using AutoMapper;
using DartsApp.RestAPI.DTOs.PlayerDto;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IEnumerable<PlayerViewDto>> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();

            return players;
        }

        [HttpGet("{id}")]
        public async Task<PlayerViewDto> GetPlayerById(int id)
        {

            return await _playerService.GetPlayerByIdAsync(id); ;
        }

        [HttpPost]
        public async Task<PlayerCreateDto> AddNewPlayer(PlayerCreateDto playerDto)
        {
            return await _playerService.AddPlayerAsync(playerDto);

        }

        [HttpPut]
        public async Task<PlayerCreateDto> UpdatePlayerById(PlayerCreateDto playerDto)
        {
            return await _playerService.UpdatePlayerAsync(playerDto);


        }

        [HttpDelete("{id}")]
        public async Task DeletePlayerById(int id)
        {
            await _playerService.DeleteAsync(id);

            //TODO dać informacje zwrotną

        }

        [HttpGet("highest-ranking")]
        public async Task<PlayerRankingDto> GetPlayerWithHighestRankingPlace()
        {
            PlayerRankingDto player = await _playerService.GetPlayerWithHighestRankingPlace();

            return player;
        }

        [HttpGet("without-ranking-points")]
        public async Task<IEnumerable<PlayerRankingDto>> GetPlayersWithoutRankingPoints()
        {
            var players = await _playerService.GetPlayersWithoutRankingPoints();

            return players;

        }

        [HttpGet("ranking-point-under-200")]
        public async Task<IEnumerable<PlayerRankingDto>> GetPlayersWithRankingPointsUnder200()
        {

            IEnumerable <PlayerRankingDto> players = await _playerService.GetPlayersWithRankingPointsUnder200();

            return players;
        }

        [HttpGet("statistic-for-player/{id}")]
        public string GetPlayerStatisticsByPlayerId(int id)
        {

            string playerStatistic = _playerService.GetPlayerStatisticsByPlayerId(id);

            return playerStatistic;

        }
    }
}
