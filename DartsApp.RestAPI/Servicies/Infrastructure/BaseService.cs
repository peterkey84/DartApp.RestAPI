using AutoMapper;
using DartsApp.RestAPI.Repositories.Interfaces;
using DartsApp.RestAPI.Servicies.Interfaces;

namespace DartsApp.RestAPI.Servicies.Infrastructure
{
    public class BaseService<TEntity> : IBaseService<TEntity>  where TEntity : class
    {

        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
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

            if (entity == null)
            {
                throw new Exception();
            }
            await _repository.DeleteAsync(entity);
        }
    }  
}
