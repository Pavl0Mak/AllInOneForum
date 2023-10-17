using AllInOneForum.Services.Contracts.Models;
using AllInOneForum.Services.Contracts.Interfaces;
using AllInOneForum.DataAccess.Contracts.Interfaces;
using AllInOneForum.DataAccess.Models;
using AllInOneForum.Utils;
using AutoMapper;
using Serilog;
using System.Collections;

namespace AllInOneForum.Services.Services
{
    public partial class UserService : IUserServiceAsync
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserService(IGenericRepository<User> repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserModel>> LoginUserAsync(UpSertUserModel user)
        {
            _logger.Information("Trying to login the user");
            
            return _mapper.Map<IEnumerable<UserModel>>(await _repository.GetAsync(filter: p =>
            {
                p = p.Where(m => m.Email == user.Email && m.PasswordHash == HashPassword.GetHashString(user.Password));

                return p;
            }));
        }

        public async Task<int?> RegisterUserAsync(UpSertUserModel user)
        {
            _logger.Information($"Registering user Name-{user.Name}, Email-{user.Email}");
        
            int? result = await _repository.AddAsync(_mapper.Map<User>(user));
        
            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var processedUsers = new List<UserModel>();
            var obtainedUsers = await _repository.GetAsync();

            obtainedUsers.ToList().ForEach(user => processedUsers.Add(_mapper.Map<UserModel>(user)));

            _logger.Information("Receiving user list");
        
            return processedUsers;
        }
    }
}