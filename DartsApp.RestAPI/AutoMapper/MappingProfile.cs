using AutoMapper;
using DartsApp.RestAPI.DTOs.BoardDto;
using DartsApp.RestAPI.DTOs.PlaceDto;
using DartsApp.RestAPI.DTOs.PlayerDto;
using DartsApp.RestAPI.DTOs.TournamentDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.AutoMapper
{
    public class MappingProfile: Profile 
    {

        public MappingProfile()
        {
            BoardMapping();
            PlaceMapping();
            PlayerMapping();
            TournamentMapping();
        }

        private void BoardMapping()
        {
            CreateMap<BoardDto, Board>();
            CreateMap<Board, BoardDto>();

            CreateMap<Board, BoardViewDto>();
        }

        private void PlaceMapping()
        {

            CreateMap<PlaceCreateDto, Place>();
            CreateMap<Place, PlaceCreateDto>();

            CreateMap<Place, PlaceViewDto>();

        }

        private void PlayerMapping()
        {
            CreateMap<PlayerCreateDto, Player>();
            CreateMap<Player, PlayerCreateDto>();

            CreateMap<Player, PlayerViewDto>().ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>src.FirstName + " " + src.LastName));

            CreateMap<PlayerRankingDto, Player>();
            CreateMap<Player, PlayerRankingDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
        }

        private void TournamentMapping()
        {   
            CreateMap<TournamentCreateDto, Tournament>();
            CreateMap<Tournament, TournamentCreateDto>();

            CreateMap<TournamentViewDto, Tournament>();
            CreateMap<Tournament, TournamentViewDto>().ForMember(d =>d.FormattedTournamentDate, opt=>opt.MapFrom(src =>src.TournamentDate.ToString("yyyy-MM-dd")));

            CreateMap<Tournament, TournamentMatchedDto>().ForMember(d => d.FormattedTournamentDate, opt => opt.MapFrom(src => src.TournamentDate.ToString("yyyy-MM-dd")));

        }
    }
}
