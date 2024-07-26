using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _playerService;

        public PlayerController(IMapper mapper, IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetAllAsync();

            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);

            if(player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPlayer(PlayerCreateDto playerDto)
        {
            await _playerService.AddAsync(playerDto);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayerById()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerById(int id)
        {
            await _playerService.DeleteAsync(id);

            return Ok();
        }
    }
}
