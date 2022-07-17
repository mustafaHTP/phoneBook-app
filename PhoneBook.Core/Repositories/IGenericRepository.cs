using System.Linq.Expressions;

namespace PhoneBook.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();

        // productRepository.where(x => x.id > 5). after tolist make a query
        // productRepository.where(x => x.id > 5).OrderBy().ToListAsync();
        // IQueryable objects, is not going to be queried, in memory
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
