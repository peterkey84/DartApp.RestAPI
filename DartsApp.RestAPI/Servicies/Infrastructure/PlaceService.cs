using AutoMapper;
using DartsApp.RestAPI.DTOs.PlaceDto;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure


{
    public class PlaceService : BaseService<PlaceCreateDto, Place>, IPlaceService
    {

        private readonly IMapper _mapper;
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository, IMapper mapper) : base(placeRepository, mapper)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PlaceCreateDto placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);

            await _placeRepository.AddAsync(place);
        }

        public async Task UpdateAsync(int id, PlaceCreateDto placeDto)
        {
            var existingPlace = await _placeRepository.GetByIdAsync(id);

            if(existingPlace == null)
            {
                throw new Exception("Place not found");
            }

            bool hasChanges = false;

            if(existingPlace.Name != placeDto.Name)
            {
                existingPlace.Name = placeDto.Name;
                hasChanges = true;

            }

            if(existingPlace.ContactEmail != placeDto.ContactEmail)
            {
                existingPlace.ContactEmail = placeDto.ContactEmail;
                hasChanges = true;
            }

            if(existingPlace.ContactNumber != placeDto.ContactNumber)
            {
                existingPlace.ContactNumber = placeDto.ContactNumber;
                hasChanges = true;
            }

            await _placeRepository.UpdateAsync(existingPlace);
        }
    }
}
