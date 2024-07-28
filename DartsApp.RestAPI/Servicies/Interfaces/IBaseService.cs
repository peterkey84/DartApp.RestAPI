namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IBaseService<TDto, TEntity> where TDto: class where TEntity: class 
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task AddAsync(TDto dto);
        Task UpdateAsync(int id, TDto dto);
        Task DeleteAsync(int id);
    }
}
