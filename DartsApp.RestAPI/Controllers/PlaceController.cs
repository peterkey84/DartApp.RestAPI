using AutoMapper;
using DartsApp.RestAPI.DTOs.PlaceDto;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class PlaceController : ControllerBase
    {

        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {

            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IEnumerable<PlaceViewDto>> GetAllPlaces()
        {
            return await _placeService.GetAllPlacesAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<PlaceViewDto> GetPlaceById(int id)
        {
            return await _placeService.GetPlaceByIdAsync(id);
        }

        
        [HttpPost]
        public async Task<PlaceViewDto> AddNewPlace(PlaceCreateDto placeDto)
        {
           return await _placeService.AddPlaceAsync(placeDto);
        }

        [HttpPut]
        public async Task<PlaceViewDto> UpdatePlaceById(PlaceCreateDto placeDto)
        {
            return await _placeService.UpdatePlaceAsync(placeDto);
        }

        [HttpDelete("{id}")]
        public async Task DeletePlaceById(int id)
        {
            await _placeService.DeleteAsync(id);
            //TODO dać info zwrotne

        }
    }
}
