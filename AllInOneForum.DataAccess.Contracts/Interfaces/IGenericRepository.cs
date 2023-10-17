namespace AllInOneForum.DataAccess.Contracts.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        public Task<int?> AddAsync(T item);

        public Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> filter = null);
    }
}
