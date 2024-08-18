using AutoMapper;
using DartsApp.RestAPI.DTOs.TournamentDto;
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

        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {

            _tournamentService = tournamentService;
        }
        [HttpGet]
        public async Task<IEnumerable<TournamentViewDto>> GetAllTournaments()
        {
            return await _tournamentService.GetAllTournamentsAsync(); ;
        }

        [HttpGet("{id}")]
        public async Task<TournamentViewDto> GetTournamentById(int id)
        {
            return await _tournamentService.GetTournamentByIdAsync(id); ;
        }

        [HttpPost]
        public async Task<TournamentCreateDto> AddNewTournament(TournamentCreateDto tournamentCreateDto)
        {
           return await _tournamentService.AddTournamentAsync(tournamentCreateDto);
        }

        [HttpPut]
        public async Task<TournamentCreateDto> UpdateTournamentById(TournamentCreateDto tournament)
        {
            return await _tournamentService.UpdateTournamentAsync(tournament);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTournamentById(int id)
        {
           await _tournamentService.DeleteAsync(id);
            //TODO dodać info zwrotne
        }


        [HttpGet("locatad-in-the-{city}")]
        public async Task<IEnumerable<TournamentMatchedDto>> GetMatchedCities(string city)
        {
            var tournaments = await _tournamentService.GetMatchedCities(city);

            return tournaments;

        }

    }
}
