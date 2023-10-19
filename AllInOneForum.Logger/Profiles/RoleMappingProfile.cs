using AllInOneForum.Contracts.DTOs;
using AllInOneForum.DataAccess.Contracts.Models;
using AllInOneForum.Services.Contracts.Models;
using AllInOneForum.Utils.Resolvers;
using AutoMapper;

namespace AllInOneForum.Utils.Profiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, RoleDTO>();
        }
    }
}
