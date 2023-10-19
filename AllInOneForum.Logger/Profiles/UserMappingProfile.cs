using AllInOneForum.Contracts.DTOs;
using AllInOneForum.DataAccess.Contracts.Models;
using AllInOneForum.Services.Contracts.Models;
using AllInOneForum.Utils.Resolvers;
using AutoMapper;

namespace AllInOneForum.Utils.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(b => b.Role, c => c.MapFrom<UserToUserModelResolver>());
            CreateMap<UserModel, UserDTO>();
            CreateMap<UpSertUserDTO, UpSertUserModel>();
            CreateMap<UpSertUserModel, User>()
                .ForMember(b => b.PasswordHash, o => o.MapFrom<UpSertUserModelToUserResolver>());
        }
    }
}