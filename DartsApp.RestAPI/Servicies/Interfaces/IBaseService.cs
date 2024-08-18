namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IBaseService<TEntity> where TEntity: class 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
