using AutoMapper;
using DartsApp.RestAPI.DTOs;
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

            var boards = await _boardService.GetAllAsync();
            return boards;
        }

        [HttpGet("{id}")]
        public async Task<BoardDto> GetBoardById(int id)
        {
            var board = await _boardService.GetByIdAsync(id);

            return board;
      

        }

        [HttpPost]
        public async Task AddNewBoard(BoardDto boardDto)
        {

            await _boardService.AddAsync(boardDto);
            
        }


        [HttpPut("{id}")]
        public async Task UpdateBoardById(int id, BoardDto boardDto)
        {

            var board = await _boardService.GetByIdAsync(id);

            if(board != null)
            {
                await _boardService.UpdateAsync(id, boardDto);

            }          
        }


        [HttpDelete("{id}")]
        public async Task DeleteBoardById(int id)
        {
            await _boardService.DeleteAsync(id);
        }


    }
}
