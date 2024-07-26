using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
