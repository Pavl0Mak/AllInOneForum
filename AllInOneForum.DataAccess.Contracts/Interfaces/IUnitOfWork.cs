using AllInOneForum.DataAccess.Contracts.Models;

namespace AllInOneForum.DataAccess.Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; set; }
        IGenericRepository<Role> RoleRepository { get; set; }
        Task SaveChangesAsync();
    }
}
