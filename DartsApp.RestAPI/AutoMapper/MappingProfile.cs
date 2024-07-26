using AutoMapper;
using DartsApp.RestAPI.DTOs;
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
        }

        private void TournamentMapping()
        {   
            CreateMap<TournamentCreateDto, Tournament>();
            CreateMap<Tournament, TournamentCreateDto>();

        }
    }
}
