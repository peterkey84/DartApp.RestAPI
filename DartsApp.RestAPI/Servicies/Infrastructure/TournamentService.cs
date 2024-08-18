using AutoMapper;
using DartsApp.RestAPI.DTOs.TournamentDto;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class TournamentService : BaseService<Tournament>, ITournamentService
    {
        private readonly IMapper _mapper;
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper) : base(tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TournamentViewDto>> GetAllTournamentsAsync()
        {
            return _mapper.Map<IEnumerable<TournamentViewDto>>(await base.GetAllAsync());
        }

        public async Task<TournamentViewDto> GetTournamentByIdAsync(int id)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(id);
            if(tournament == null)
            {
                //todo
            }

            return _mapper.Map<TournamentViewDto>(tournament);
        }

        public async Task<TournamentCreateDto> AddTournamentAsync(TournamentCreateDto tournamentDto)
        {

            var tournament = _mapper.Map<Tournament>(tournamentDto);

            await base.AddAsync(tournament);

            return _mapper.Map<TournamentCreateDto>(await _tournamentRepository.GetByIdAsync(tournament.Id));


        }

        public async Task<TournamentCreateDto> UpdateTournamentAsync(TournamentCreateDto tournamentDto)
        {
            var id = tournamentDto.Id;

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

            return _mapper.Map<TournamentCreateDto>(await _tournamentRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<TournamentMatchedDto>> GetMatchedCities(string city)
        {

           var ttt = await _tournamentRepository.GetMatchedCities(city);

            return  _mapper.Map<IEnumerable<TournamentMatchedDto>>(ttt);


        }


    }
}
