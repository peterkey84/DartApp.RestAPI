﻿using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Player> PlayerWithHighestRankingPlace()
        {
            var player =  _dbContext.Players.OrderByDescending(p=>p.Ranking).FirstOrDefault();

            return player;
        }

        public async Task<IEnumerable<Player>> PlayerWithoutRankingPoints()
        {

            var players = await _dbContext.Players.Where(x => x.Ranking == 0).ToListAsync();

            return players;

        }

        public async Task<IEnumerable<Player>> GetPlayersWithRankingPointsUnder200()
        {
            IEnumerable<Player> players = await _dbContext.Players.TakeWhile(p => p.Ranking < 200).ToListAsync();
            
            return players;
        }

        public string GetPlayerStatisticsByPlayerId(int id)
        {

            IQueryable<string> players = _dbContext.PlayerTournaments.Where(p => p.PlayerId == id).Select(x => x.PlayerStatistics);
            
            var statisticOfPlayer = players.FirstOrDefault();

            if (statisticOfPlayer == null)
            {
                throw new Exception();
            }

            return statisticOfPlayer;

        }

        public int GetTournamentIdByPlayerId(int id)
        {

            IQueryable<int> tournamentId = _dbContext.PlayerTournaments.Where(p => p.PlayerId == id).Select(x => x.TournamentId);

            var returnTournamentId = tournamentId.FirstOrDefault();

            if(returnTournamentId == null)
            {
                throw new Exception();
            }

            return returnTournamentId;
        }
        public async Task AddPlayerTournamnetAsync(PlayerTournament playerTournamnet)
        {
            if (playerTournamnet != null)
            {
                await _dbContext.PlayerTournaments.AddAsync(playerTournamnet);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PlayerTournament> GetPlayerTournament(int playerId)
        {
            IQueryable<PlayerTournament> playerTournamentValues = _dbContext.PlayerTournaments.Where(p => p.PlayerId == playerId);

            var playerTournament = playerTournamentValues.FirstOrDefault();

            if(playerTournament == null)
            {
                throw new Exception();

            }

            return playerTournament;
        }
    }
}
