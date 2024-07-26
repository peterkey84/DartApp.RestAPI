using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {

        private readonly IBoardService _boardService;

        public BoardController( IBoardService boardService)
        {

            _boardService = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoards()
        {

            var boards = await _boardService.GetAllAsync();

            return Ok(boards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoardById(int id)
        {
            var board = await _boardService.GetByIdAsync(id);

            if(board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        [HttpPost]
        public async Task<ActionResult<BoardDto>> AddNewBoard(BoardDto boardDto)
        {

            await _boardService.AddAsync(boardDto);

            return CreatedAtAction(nameof(GetBoardById), new {id = boardDto.Id}, boardDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoardById(int id, BoardDto boardDto)
        {

            var board = await _boardService.GetByIdAsync(id);

            if(board != null)
            {
                await _boardService.UpdateAsync(id, boardDto);

                return Ok();
            }
            
            return NotFound("Invalide Board");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoardById(int id)
        {
            await _boardService.DeleteAsync(id);
            return Ok();
        }


    }
}
