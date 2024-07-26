using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class BoardService : Service<BoardDto, Board>, IBoardService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Board> _repository;
        private readonly ITournamentRepository _tournamentRepository;

        public BoardService(IRepository<Board> repository, IMapper mapper, ITournamentRepository tournamentRepository) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _tournamentRepository = tournamentRepository;
        }

        public async Task AddAsync(BoardDto boardDto)
        {
            var board = _mapper.Map<Board>(boardDto);

            var id = await _tournamentRepository.GetByIdAsync(boardDto.TournamentId);

            if(id == null)
            {
                throw new Exception("Invalid TournamentId");
            }
            else
            {
                await _repository.AddAsync(board);

            }

        }


        public async Task UpdateAsync(int id, BoardDto boardDto)
        {
            var existingBoard = await _repository.GetByIdAsync(id);

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
                await _repository.UpdateAsync(existingBoard);

            }

        }
    }
}
