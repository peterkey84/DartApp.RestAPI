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
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllAsync();

            return Ok(places);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaceById(int id)
        {

            var place = await _placeService.GetByIdAsync(id);

            if(place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddNewPlace(PlaceCreateDto placeDto)
        {
            await _placeService.AddAsync(placeDto);

            return CreatedAtAction(nameof(GetPlaceById), new { id = placeDto.Id }, placeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlaceById(int id, PlaceCreateDto placeDto)
        {
            await _placeService.UpdateAsync(id, placeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaceById(int id)
        {
            await _placeService.DeleteAsync(id);
            return Ok();
        }
    }
}
