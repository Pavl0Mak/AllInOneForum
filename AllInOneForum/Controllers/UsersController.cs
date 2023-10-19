using Microsoft.AspNetCore.Mvc;
using AllInOneForum.Contracts.DTOs;
using AllInOneForum.Services.Contracts.Models;
using AllInOneForum.Services.Contracts.Interfaces;
using AutoMapper;

namespace AllInOneForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController (IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost(nameof(LoginUserAsync))]
        public async Task<IActionResult> LoginUserAsync([FromQuery] UpSertUserDTO user)
        {
            var receivedUser = (await _userService.LoginUserAsync(_mapper.Map<UpSertUserModel>(user)));

            if (receivedUser != null)
            {
                return Ok(_mapper.Map<UserDTO>(receivedUser));
            } 
            else 
            { 
                return BadRequest(); 
            }
        }

        [HttpPost(nameof(RegisterUserAsync))]
        public async Task<IActionResult> RegisterUserAsync([FromQuery] UpSertUserDTO user)
        {
            return Created(string.Empty, await _userService.RegisterUserAsync(_mapper.Map<UpSertUserModel>(user)));
        }

        [HttpGet(nameof(GetUsersAsync))]
        public async Task<IActionResult> GetUsersAsync()
        {
            var processedUsers = new List<UserDTO>();
            var receiverUsers = await _userService.GetUsersAsync();

            receiverUsers.ToList().ForEach(user => processedUsers.Add(_mapper.Map<UserDTO>(user)));

            return Ok(processedUsers);
        }
    }
}
