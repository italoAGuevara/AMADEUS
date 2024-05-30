

namespace Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
