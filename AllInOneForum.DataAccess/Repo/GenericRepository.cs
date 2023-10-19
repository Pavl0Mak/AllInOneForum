using AllInOneForum.DataAccess.Contracts.Interfaces;
using AllInOneForum.DataAccess.Contracts.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AllInOneForum.DataAccess.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity 
    {
        EntitiesDBContext _context;
        DbSet<T> _dbset;

        public GenericRepository(EntitiesDBContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task<int?> AddAsync(T item)
        {
            await _dbset.AddAsync(item);

            return item.Id;
        }

        public async Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> filter = null)
        {
            IQueryable<T> query = _dbset;
            query = filter != null ? filter(query): query;

            return await query.ToListAsync();
        }
    }
}