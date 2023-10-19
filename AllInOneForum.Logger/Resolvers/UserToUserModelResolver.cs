using AllInOneForum.DataAccess.Contracts.Models;
using AllInOneForum.Services.Contracts.Models;
using AutoMapper;

namespace AllInOneForum.Utils.Resolvers
{
    public class UserToUserModelResolver : IValueResolver<User, UserModel, RoleModel>
    {
        public RoleModel Resolve(User source, UserModel destination, RoleModel destMember, ResolutionContext context)
        {
            return new RoleModel();
        }
    }
}
