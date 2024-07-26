using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private readonly IMapper _mapper;

        public TournamentController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTournaments()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournamentById()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTournament()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTournamentById()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTournamentById()
        {
            return Ok();
        }
    }
}
