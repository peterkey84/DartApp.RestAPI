using DartsApp.RestAPI.DTOs.BoardDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IBoardService : IBaseService<Board>
    {
        Task<IEnumerable<BoardViewDto>> GetAllBoardsAsync(); 
        Task<BoardDto> GetBoardByIdAsync(int id);
        Task<BoardViewDto> AddBoardAsync(BoardDto boardDto);
        Task<BoardDto> UpdateBoardAsync(BoardDto boardDto);
    }
}
