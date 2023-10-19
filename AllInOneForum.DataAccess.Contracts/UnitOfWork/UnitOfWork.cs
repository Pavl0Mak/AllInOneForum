using AllInOneForum.DataAccess.Contracts.DataContext;
using AllInOneForum.DataAccess.Contracts.Interfaces;
using AllInOneForum.DataAccess.Contracts.Models;

namespace AllInOneForum.DataAccess.Contracts.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesDBContext _context;

        public IGenericRepository<User> UserRepository { get; set; }
        public IGenericRepository<Role> RoleRepository { get; set; } 

        public UnitOfWork(EntitiesDBContext context,
            IGenericRepository<User> userRepository,
            IGenericRepository<Role> roleRepository)
        {
            _context = context;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
