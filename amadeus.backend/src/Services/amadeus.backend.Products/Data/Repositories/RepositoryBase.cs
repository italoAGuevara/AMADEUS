
namespace Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        #region "async methods"
        public async Task<IReadOnlyList<T>> GetAsync(int? PageNumber = 1, int? PageSize = 10)
        {
            return await _context.Set<T>()
                    .Skip(((PageNumber - 1) * PageSize) ?? 0)
                    .Take(PageSize ?? 10)
                    .OrderByDescending(x => x.TmStmp)
                    .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            //_logger.LogInformation($"finding product by id async '{id.ToString()}'");
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        } 
        
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //_logger.LogInformation($"getting all entitys");
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            //_logger.LogInformation($"adding async entity '{entity.Id}' {entity.GetType}");
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //_logger.LogInformation($"updating async entity '{entity.Id}' {entity.GetType}");
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            //_logger.LogInformation($"deleting async entity '{entity.Id}' {entity.GetType}");
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region "NOT asyn methods"
        public void AddEntity(T entity)
        {
            //_logger.LogInformation($"adding entity '{entity.Id}' {entity.GetType}");
            _context.Set<T>().Add(entity);
        }
        public void UpdateEntity(T entity)
        {
            //_logger.LogInformation($"updating  entity '{entity.Id}' {entity.GetType}");
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity(T entity)
        {
            //_logger.LogInformation($"deleting  entity '{entity.Id}' {entity.GetType}");
            _context.Set<T>().Remove(entity);
        }
        #endregion
    }
}
