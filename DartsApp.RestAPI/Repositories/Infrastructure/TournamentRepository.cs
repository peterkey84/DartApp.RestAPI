using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
