using AutoMapper;
using DartsApp.RestAPI.DTOs.PlaceDto;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure


{
    public class PlaceService : BaseService<Place>, IPlaceService
    {

        private readonly IMapper _mapper;
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository, IMapper mapper) : base(placeRepository)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<PlaceViewDto>> GetAllPlacesAsync()
        {
            var places = await base.GetAllAsync();

            return _mapper.Map<IEnumerable<PlaceViewDto>>(places); ;

        }


        public async Task<PlaceViewDto> GetPlaceByIdAsync(int id)
        {

            var place = await base.GetByIdAsync(id);

            if(place == null)
            {
                //TODO
            }

            return _mapper.Map<PlaceViewDto>(place);


        }


        public async Task<PlaceViewDto> AddPlaceAsync(PlaceCreateDto placeDto)
        {

            var place = _mapper.Map<Place>(placeDto);

            await base.AddAsync(place);

            return _mapper.Map<PlaceViewDto>(await _placeRepository.GetByIdAsync(place.Id));


        }



        public async Task<PlaceViewDto> UpdatePlaceAsync(PlaceCreateDto placeDto)
        {
            var id = placeDto.Id;
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

            if(existingPlace.City != placeDto.City)
            {
                existingPlace.City = placeDto.City;
                hasChanges = true;
            }

            if (existingPlace.Street != placeDto.Street)
            {
                existingPlace.Street = placeDto.Street;
                hasChanges = true;
            }

            if (existingPlace.PostalCode != placeDto.PostalCode)
            {
                existingPlace.PostalCode = placeDto.PostalCode;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await base.UpdateAsync(existingPlace);

            }

            return _mapper.Map<PlaceViewDto>(await _placeRepository.GetByIdAsync(id));
        } 

    }
}
