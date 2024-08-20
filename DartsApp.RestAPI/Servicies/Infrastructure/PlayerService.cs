using AutoMapper;
using DartsApp.RestAPI.DTOs.PlayerDto;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;
using DartsApp.RestAPI.Settings;
using Microsoft.Extensions.Options;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class PlayerService : BaseService<Player>, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        private readonly PlayerSettings _playerSettings;
        private readonly PlayerValidation _playerValidation;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper, IOptions<PlayerSettings> playerSettings, IOptions<PlayerValidation> playerValidation) : base(playerRepository)
        {
            
            _mapper = mapper;
            _playerRepository = playerRepository;
            _playerSettings = playerSettings.Value;
            _playerValidation = playerValidation.Value;

        }


        public async Task<IEnumerable<PlayerViewDto>> GetAllPlayersAsync()
        {

            var players = await base.GetAllAsync();

            return _mapper.Map<IEnumerable<PlayerViewDto>>(players); ;
        }

        public async Task<PlayerViewDto> GetPlayerByIdAsync(int id)
        {

            var player = await base.GetByIdAsync(id);
            if(player == null)
            {
                throw new Exception();
            }

            return _mapper.Map<PlayerViewDto>(player);
        }

        public async Task<PlayerCreateDto> AddPlayerAsync(PlayerCreateDto playerDto)
        {

            var player = _mapper.Map<Player>(playerDto);

            var age = CalculateAge(playerDto.BirthdayDate);

            if(age < _playerValidation.MinimumAge)
            {
                throw new Exception("Player is too young to register.");
            }

            player = new Player()
            {
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                ContactEmail = playerDto.ContactEmail,
                ContactNumber = playerDto.ContactNumber,
                BirthdayDate = playerDto.BirthdayDate,
                Ranking = _playerSettings.DefaultRanking
            };

            await base.AddAsync(player);

            return _mapper.Map<PlayerCreateDto>(await _playerRepository.GetByIdAsync(player.Id));

        }

        public async Task<PlayerCreateDto> UpdatePlayerAsync(PlayerCreateDto playerDto)
        {
            var id = playerDto.Id;
            var existingPlayer = await _playerRepository.GetByIdAsync(id);

            if (existingPlayer == null)
            {
                throw new Exception();
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

            return _mapper.Map<PlayerCreateDto>(await _playerRepository.GetByIdAsync(id)); 

        }


        public async Task <PlayerRankingDto> GetPlayerWithHighestRankingPlace()
        {
            var player = await _playerRepository.PlayerWithHighestRankingPlace();

            PlayerRankingDto playerDto = _mapper.Map<PlayerRankingDto>(player);

            return playerDto;

        }


        public async Task<IEnumerable<PlayerRankingDto>> GetPlayersWithoutRankingPoints()
        {
            var players = await _playerRepository.PlayerWithoutRankingPoints();

            var playerDto = _mapper.Map<IEnumerable<PlayerRankingDto>>(players);

            return playerDto;
        }

        public async Task<IEnumerable<PlayerRankingDto>> GetPlayersWithRankingPointsUnder200()
        {
            var players = await _playerRepository.GetPlayersWithRankingPointsUnder200();

            IEnumerable<PlayerRankingDto> playerDto = _mapper.Map< IEnumerable<PlayerRankingDto>>(players);

            return playerDto;

        }

        public string GetPlayerStatisticsByPlayerId(int playerId)
        {

            var player = _playerRepository.GetPlayerStatisticsByPlayerId(playerId);

            if(player == null)
            {
                throw new Exception();
            }

            return player;

        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

    }
}
