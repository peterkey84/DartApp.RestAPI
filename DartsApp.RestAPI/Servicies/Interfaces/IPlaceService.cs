using DartsApp.RestAPI.DTOs.PlaceDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IPlaceService: IBaseService<Place>
    {
        Task<IEnumerable<PlaceViewDto>> GetAllPlacesAsync();
        Task<PlaceViewDto> GetPlaceByIdAsync(int id);
        Task<PlaceViewDto> AddPlaceAsync(PlaceCreateDto placeDto);
        Task<PlaceViewDto> UpdatePlaceAsync(PlaceCreateDto placeDto);
    }
}
