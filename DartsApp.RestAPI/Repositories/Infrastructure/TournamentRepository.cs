using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public TournamentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Tournament>> GetMatchedCities(string city)
        {

            IEnumerable<Tournament> tournaments = await _dbContext.Tournaments.Include(c => c.Place).ToListAsync();

            var matchedTournaments = tournaments.Where(p => p.Place.City.ToUpper() == city.ToUpper());

            return matchedTournaments;
        }


    }
}
