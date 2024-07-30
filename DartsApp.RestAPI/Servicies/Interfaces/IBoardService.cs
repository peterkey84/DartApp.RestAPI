using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IBoardService : IBaseService<BoardDto, Board>
    {
      new Task<IEnumerable<BoardViewDto>> GetAllAsync();
    }
}
