using AllInOneForum.Services.Contracts.Models;

namespace AllInOneForum.Services.Contracts.Interfaces
{
    public interface IUserServiceAsync
    {
        public Task<IEnumerable<UserModel>> LoginUserAsync(UpSertUserModel user);
        public Task<int?> RegisterUserAsync(UpSertUserModel user);
        public Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}
