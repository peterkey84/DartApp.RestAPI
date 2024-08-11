using AutoMapper;
using DartsApp.RestAPI.DTOs.TournamentDto;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class TournamentService : BaseService<TournamentCreateDto, Tournament>, ITournamentService
    {
        private readonly IMapper _mapper;
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper) : base(tournamentRepository, mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TournamentViewDto>> GetAllAsync()
        {
            var tournaments = await _tournamentRepository.GetAllAsync();

            var tournamentsDto = _mapper.Map<IEnumerable<TournamentViewDto>>(tournaments);

            return tournamentsDto;
        }



        public async Task UpdateAsync(int id, TournamentCreateDto tournamentDto)
        {
            var existingTournament = await _tournamentRepository.GetByIdAsync(id);

            if (existingTournament == null)
            {
                throw new Exception("Tournament not found");
            }

            bool hasChanges = false;

            if (existingTournament.Name != tournamentDto.Name)
            {
                existingTournament.Name = tournamentDto.Name;
                hasChanges = true;
            }

            if (existingTournament.TournamentDate != tournamentDto.TournamentDate)
            {
                existingTournament.TournamentDate = tournamentDto.TournamentDate;
                hasChanges = true;
            }

            if (existingTournament.PlaceId != tournamentDto.PlaceId)
            {
                existingTournament.PlaceId = tournamentDto.PlaceId;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await _tournamentRepository.UpdateAsync(existingTournament);

            }
        }

        public async Task<IEnumerable<TournamentMatchedDto>> GetMatchedCities(string city)
        {

           var ttt = await _tournamentRepository.GetMatchedCities(city);

            return  _mapper.Map<IEnumerable<TournamentMatchedDto>>(ttt);


        }
    }
}
