using AllInOneForum.Services.Contracts.Models;

namespace AllInOneForum.Services.Contracts.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel> LoginUserAsync(UpSertUserModel user);
        public Task<int?> RegisterUserAsync(UpSertUserModel user);
        public Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}
