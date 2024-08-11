using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ITournamentService _tournamentService;

        public TournamentController(IMapper mapper, ITournamentService tournamentService)
        {
            _mapper = mapper;
            _tournamentService = tournamentService;
        }
        [HttpGet]
        public async Task<IEnumerable<TournamentViewDto>> GetAllTournaments()
        {

            IEnumerable<TournamentViewDto> tournaments = await _tournamentService.GetAllAsync();

            return tournaments;
        }

        [HttpGet("{id}")]
        public async Task<TournamentCreateDto> GetTournamentById(int id)
        {

            var tournament = await _tournamentService.GetByIdAsync(id);

            return tournament;

        }

        [HttpPost]
        public async Task AddNewTournament(TournamentCreateDto tournamentCreateDto)
        {
            await _tournamentService.AddAsync(tournamentCreateDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateTournamentById(TournamentCreateDto tournament, int id)
        {
            await _tournamentService.UpdateAsync(id, tournament);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTournamentById(int id)
        {
           await _tournamentService.DeleteAsync(id);
        }


        [HttpGet("locatad-in-the-{city}")]
        public async Task<IEnumerable<TournamentMatchedDto>> GetMatchedCities(string city)
        {
            var tournaments = await _tournamentService.GetMatchedCities(city);

            return tournaments;

        }

    }
}
