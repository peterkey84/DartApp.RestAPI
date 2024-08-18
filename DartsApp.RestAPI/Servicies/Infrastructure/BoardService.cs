using AutoMapper;
using DartsApp.RestAPI.DTOs.BoardDto;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class BoardService : BaseService<Board>, IBoardService
    {
        private readonly IMapper _mapper;
        private readonly IBoardRepository _boardRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public BoardService(IBaseRepository<Board> baseRepository, IMapper mapper, ITournamentRepository tournamentRepository, IBoardRepository boardRepository) : base(baseRepository)
        {
            _mapper = mapper;
            _tournamentRepository = tournamentRepository;
            _boardRepository = boardRepository;
        }

        public async Task<IEnumerable<BoardViewDto>> GetAllBoardsAsync()
        {
            var boards = await base.GetAllAsync();

            return _mapper.Map<IEnumerable<BoardViewDto>>(boards);
        }


        public async Task<BoardDto> GetBoardByIdAsync(int id)
        {

            var board = await base.GetByIdAsync(id);
            if(board == null)
            {
                //TODO
            }

            return _mapper.Map<BoardDto>(board);
        }
        public async Task<BoardViewDto> AddBoardAsync(BoardDto boardDto)
        {
            var board = _mapper.Map<Board>(boardDto);

            var id = await _tournamentRepository.GetByIdAsync(boardDto.TournamentId);

            if(id == null)
            {
                throw new Exception("Invalid TournamentId");
            }

            await base.AddAsync(board);

            return _mapper.Map<BoardViewDto>(await _boardRepository.GetByIdAsync(board.Id)); ;

        }

        public async Task<BoardDto> UpdateBoardAsync(BoardDto boardDto)
        {
            int id = boardDto.Id;
            var existingBoard = await _boardRepository.GetByIdAsync(id);

            if(existingBoard == null)
            {
                throw new Exception("Board not found");
            }

            bool hasChanges = false;

            if(existingBoard.Brand != boardDto.Brand)
            {
                existingBoard.Brand = boardDto.Brand;
                hasChanges = true;
            }

            if(existingBoard.Model != boardDto.Model)
            {
                existingBoard.Model = boardDto.Model;
                hasChanges = true;

            }

            if (existingBoard.Type != boardDto.Type)
            {
                existingBoard.Type = boardDto.Type;
                hasChanges = true;

            }

            if(existingBoard.TournamentId != boardDto.TournamentId)
            {
                var newTournamentId = await _tournamentRepository.GetByIdAsync(boardDto.TournamentId);

                if(newTournamentId == null)
                {
                    throw new Exception("Invalid TournamentId");
                }

                existingBoard.TournamentId = boardDto.TournamentId;
                hasChanges = true;

            }

            if (hasChanges)
            {
                await base.UpdateAsync(existingBoard);

            }

            return _mapper.Map<BoardDto>(await _boardRepository.GetByIdAsync(id)); ;
        }


    }
}
