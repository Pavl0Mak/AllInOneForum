using AllInOneForum.Services.Contracts.Models;
using AllInOneForum.Services.Contracts.Interfaces;
using AllInOneForum.DataAccess.Contracts.Interfaces;
using AllInOneForum.DataAccess.Contracts.Models;
using AllInOneForum.Utils;
using AutoMapper;
using Serilog;
using AllInOneForum.DataAccess.Contracts.UnitOfWork;

namespace AllInOneForum.Services.Services
{
    public partial class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserModel> LoginUserAsync(UpSertUserModel user)
        {
            _logger.Information("Trying to login the user");

            var receivedUser = (await _unitOfWork.UserRepository.GetAsync(filter: p =>
            {
                p = p.Where(m => m.Email == user.Email && m.PasswordHash == HashPassword.GetHashString(user.Password));

                return p;
            })).FirstOrDefault();

            var role = (await _unitOfWork.RoleRepository.GetAsync(filter: p => 
            {
                p = p.Where(m => m.Id == receivedUser.RoleId);

                return p;
            })).FirstOrDefault();

            var mappedUser = _mapper.Map<UserModel>(receivedUser);

            mappedUser.Role = _mapper.Map<RoleModel>(role);

            return mappedUser;
        }

        public async Task<int?> RegisterUserAsync(UpSertUserModel user)
        {
            _logger.Information($"Registering user Name-{user.Name}, Email-{user.Email}");
        
            int? result = await _unitOfWork.UserRepository.AddAsync(_mapper.Map<User>(user));
        
            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var processedUsers = new List<UserModel>();
            var obtainedUsers = await _unitOfWork.UserRepository.GetAsync();

            obtainedUsers.ToList().ForEach(user => processedUsers.Add(_mapper.Map<UserModel>(user)));

            _logger.Information("Receiving user list");
        
            return processedUsers;
        }
    }
}