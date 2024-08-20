using AutoMapper;
using DartsApp.RestAPI.DTOs.BoardDto;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;
using DartsApp.RestAPI.Settings;
using Microsoft.Extensions.Options;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class BoardService : BaseService<Board>, IBoardService
    {
        private readonly IMapper _mapper;
        private readonly IBoardRepository _boardRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly BoardSettings _boardSettings;
        private readonly BoardLimits _boardLimits;
        public BoardService(IBaseRepository<Board> baseRepository, IMapper mapper, ITournamentRepository tournamentRepository, IBoardRepository boardRepository, IOptions<BoardSettings> boardSettings, IOptions<BoardLimits> boardLimits) : base(baseRepository)
        {
            _mapper = mapper;
            _tournamentRepository = tournamentRepository;
            _boardRepository = boardRepository;
            _boardSettings = boardSettings.Value;
            _boardLimits = boardLimits.Value;
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
                throw new Exception();
            }

            return _mapper.Map<BoardDto>(board);
        }
        public async Task<BoardViewDto> AddBoardAsync(BoardDto boardDto)
        {
            var board = _mapper.Map<Board>(boardDto);

            var id = await _tournamentRepository.GetByIdAsync(boardDto.TournamentId);

            var tournament = await _tournamentRepository.GetAllWithBoardsAsync();

            var tournamnetById = tournament.FirstOrDefault(t => t.Id == boardDto.TournamentId);

            if (tournamnetById.Boards.Count >= _boardLimits.MaxBoardsPerTournament)
            {
                throw new Exception("Maximum number of boards for this tournament has been reached.");
            }

            if (id == null)
            {
                throw new Exception();
            }

            if(boardDto.Type == "")
            {
                board = new Board()
                {
                    Brand = boardDto.Brand,
                    Model = boardDto.Model,
                    Type = _boardSettings.DefautlType,
                    TournamentId = boardDto.TournamentId
                };
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
                throw new Exception();
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
