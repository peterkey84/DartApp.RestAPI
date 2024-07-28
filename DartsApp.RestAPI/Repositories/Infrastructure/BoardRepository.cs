using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BoardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }

        public override async Task<IEnumerable<Board>> GetAllAsync()
        {

                 IEnumerable<Board> List =  await _dbContext.Boards
                    .Include(b=>b.Tournament)
                    .ToListAsync();

            return List;

        }
    }
}
