using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTournamentController : ControllerBase
    {

        private readonly IPlayerTournamentService _playerTournamentService;

        public PlayerTournamentController(IPlayerTournamentService playerTournamentService)
        {
            _playerTournamentService = playerTournamentService;
        }

        [HttpGet]
        public async Task GetAllAsync()
        {

        }

        [HttpGet("players/statistic/id")]
        public string GetPlayerStatisticsByPlayerId(int id)
        {

            string playerStatistic =  _playerTournamentService.GetPlayerStatisticsByPlayerId(id);

            return playerStatistic;

        }

        [HttpGet("players/points-by-tournamnet/id")]
        public async Task GetPlayerPointsFromTournamentByPlayerIdAndTournamentId(int playerId, int tournamnetId)
        {

        }

    }
}
