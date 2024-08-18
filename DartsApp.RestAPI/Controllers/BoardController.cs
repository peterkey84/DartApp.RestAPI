using AutoMapper;
using DartsApp.RestAPI.DTOs.BoardDto;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BoardController : ControllerBase
    {

        private readonly IBoardService _boardService;

        public BoardController( IBoardService boardService)
        {

            _boardService = boardService;
        }

        [HttpGet]
        public async Task<IEnumerable<BoardViewDto>> GetAllBoards()
        {

            IEnumerable<BoardViewDto> boards = (IEnumerable<BoardViewDto>)await _boardService.GetAllBoardsAsync();

            return boards;
        }

        [HttpGet("{id}")]
        public async Task<BoardDto> GetBoardByIdAsync(int id)
        {

            return await _boardService.GetBoardByIdAsync(id);
      
        }

        [HttpPost]
        public async Task<BoardViewDto> AddNewBoard(BoardDto boardDto)
        {

            return await _boardService.AddBoardAsync(boardDto); ;
            
        }


        [HttpPut]
        public async Task<BoardDto> UpdateBoardById(BoardDto boardDto)
        {
            var id = boardDto.Id;
            var board = await _boardService.GetByIdAsync(id);

            if(board == null)
            {
                NotFound("Board Not found");
            }

            BoardDto updatedBoard = await _boardService.UpdateBoardAsync(boardDto);
            return updatedBoard;


        }


        [HttpDelete("{id}")]
        public async Task DeleteBoardById(int id)
        {
            await _boardService.DeleteAsync(id);
            //TODO dać informacje zwrotną

        }


    }
}
