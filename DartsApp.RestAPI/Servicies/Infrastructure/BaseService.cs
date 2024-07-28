using AutoMapper;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TDto : class where TEntity : class
    {

        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();

            var dtoObject = _mapper.Map<IEnumerable<TDto>>(entity);

            return dtoObject.ToList();
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var objectId = await _repository.GetByIdAsync(id);

            return _mapper.Map<TDto>(objectId);
        }

        public async Task AddAsync(TDto dto)
        {

            var addObject = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(addObject);

        }

        public async Task DeleteAsync(int id)
        {
            var deletedObject = await _repository.GetByIdAsync(id);

            if(deletedObject != null)
            {
                await _repository.DeleteAsync(deletedObject);
            }    
        }



        public async Task UpdateAsync(int id, TDto dto)
        {

            var updateObject = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(updateObject);


        }
    }  
}
