using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {

        public PlaceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


    }
}
