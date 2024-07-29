using AutoMapper;
using DartsApp.RestAPI.DTOs;
using DartsApp.RestAPI.Servicies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartsApp.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IPlaceService _placeService;

        public PlaceController(IMapper mapper, IPlaceService placeService)
        {
            _mapper = mapper;
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IEnumerable<PlaceCreateDto>> GetAllPlaces()
        {
            IEnumerable<PlaceCreateDto> places = await _placeService.GetAllAsync();

            return places;
        }

        [HttpGet("{id}")]
        public async Task<PlaceCreateDto> GetPlaceById(int id)
        {
            var place = await _placeService.GetByIdAsync(id);

            return place;
        }

        
        [HttpPost]
        public async Task AddNewPlace(PlaceCreateDto placeDto)
        {
            await _placeService.AddAsync(placeDto);

        }

        [HttpPut("{id}")]
        public async Task UpdatePlaceById(int id, PlaceCreateDto placeDto)
        {
            await _placeService.UpdateAsync(id, placeDto);
        }

        [HttpDelete("{id}")]
        public async Task DeletePlaceById(int id)
        {
            await _placeService.DeleteAsync(id);

        }
    }
}
