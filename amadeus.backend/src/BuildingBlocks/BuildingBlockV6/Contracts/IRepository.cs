namespace BuildingBlockV6.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(int? PageNumber = 1, int? PageSize = 10);

        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        void AddEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);
    }
}
