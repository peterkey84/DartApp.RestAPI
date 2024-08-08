using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class PlayerTournamentRepository : BaseRepository<PlayerTournament>, IPlayerTournamentRepository
    {

        private readonly ApplicationDbContext _dbContext;


        public PlayerTournamentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public string GetPlayerStatisticsByPlayerId(int id)
        {

            IQueryable<string> players = _dbContext.PlayerTournaments.Where(p => p.PlayerId == id).Select(x => x.PlayerStatistics);

            ;
            return players.FirstOrDefault();


        }

    }
}
