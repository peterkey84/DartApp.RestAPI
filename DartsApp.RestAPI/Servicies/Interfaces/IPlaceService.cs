using DartsApp.RestAPI.DTOs.PlaceDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IPlaceService: IBaseService<PlaceCreateDto, Place>
    {
    }
}
