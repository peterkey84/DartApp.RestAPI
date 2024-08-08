using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class PlayerTournamentService : BaseService<PlayerTournamentDto, PlayerTournament>, IPlayerTournamentService
    {

        private readonly IPlayerTournamentRepository _playerTournamentRepository;
        private readonly IMapper _mapper;

        public PlayerTournamentService(IPlayerTournamentRepository playerTournamentRepositoryt , IMapper mapper) : base(playerTournamentRepositoryt, mapper)
        {
            _playerTournamentRepository = playerTournamentRepositoryt;
            _mapper = mapper;
        }

        public string GetPlayerStatisticsByPlayerId(int playerId)
        {

            var player =  _playerTournamentRepository.GetPlayerStatisticsByPlayerId(playerId);

            return player;

        }
    }
}
