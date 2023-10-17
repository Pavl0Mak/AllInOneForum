using AllInOneForum.DataAccess.Models;
using AllInOneForum.Services.Contracts.Models;
using AutoMapper;

namespace AllInOneForum.Utils.Resolvers
{
    internal class UpSertUserModelToUserResolver : IValueResolver<UpSertUserModel, User, string>
    {
        public string Resolve(UpSertUserModel source, User destination, string destMember, ResolutionContext context)
        {
            return HashPassword.GetHashString(source.Password);
        }
    }
}