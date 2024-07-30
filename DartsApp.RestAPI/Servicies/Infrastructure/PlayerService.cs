using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class PlayerService : BaseService<PlayerCreateDto, Player>, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;


        public PlayerService(IPlayerRepository playerRepository, IMapper mapper) : base(playerRepository, mapper)
        {
            
            _mapper = mapper;
            _playerRepository = playerRepository;

        }

        async Task<IEnumerable<PlayerViewDto>> IPlayerService.GetAllAsync()
        {

            var players = await _playerRepository.GetAllAsync();

            var playersViewDto = _mapper.Map <IEnumerable<PlayerViewDto>>(players);

            return playersViewDto;

        }

        public async Task UpdateAsync(int id, PlayerCreateDto playerDto)
        {
            var existingPlayer = await _playerRepository.GetByIdAsync(id);

            if (existingPlayer == null)
            {
                throw new Exception("Player not found");
            }

            bool hasChanges = false;

            if (existingPlayer.ContactEmail != playerDto.ContactEmail)
            {
                existingPlayer.ContactEmail = playerDto.ContactEmail;
                hasChanges = true;
            }

            if(existingPlayer.FirstName != playerDto.FirstName)
            {
                existingPlayer.FirstName = playerDto.FirstName;
                hasChanges = true;
            }

            if (existingPlayer.LastName != playerDto.LastName)
            {
                existingPlayer.LastName = playerDto.LastName;
                hasChanges = true;
            }

            if (existingPlayer.ContactNumber != playerDto.ContactNumber)
            {
                existingPlayer.ContactNumber = playerDto.ContactNumber;
                hasChanges = true;
            }

            if (existingPlayer.Ranking != playerDto.Ranking)
            {
                existingPlayer.Ranking = playerDto.Ranking;
                hasChanges = true;
            }

            if (existingPlayer.BirthdayDate != playerDto.BirthdayDate)
            {
                existingPlayer.BirthdayDate = playerDto.BirthdayDate;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await _playerRepository.UpdateAsync(existingPlayer);

            }

        }


        public async Task <PlayerRankingDto> GetPlayerWithHighestRankingPlace()
        {
            var player = await _playerRepository.PlayerWithHighestRankingPlace();

            PlayerRankingDto playerDto = _mapper.Map<PlayerRankingDto>(player);

            return playerDto;

        }
    }
}
