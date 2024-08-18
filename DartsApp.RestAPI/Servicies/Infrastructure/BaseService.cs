using AutoMapper;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class BaseService<TEntity> : IBaseService<TEntity>  where TEntity : class
    {

        private readonly IBaseRepository<TEntity> _repository;
        private IPlayerRepository playerRepository;
        private IMapper mapper;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public BaseService(IPlayerRepository playerRepository, IMapper mapper)
        {
            this.playerRepository = playerRepository;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {

            await _repository.AddAsync(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {

            await _repository.UpdateAsync(entity);

            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }  
}
