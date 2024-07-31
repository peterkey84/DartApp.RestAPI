using DartsApp.RestAPI.DAL;
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
    }
}
