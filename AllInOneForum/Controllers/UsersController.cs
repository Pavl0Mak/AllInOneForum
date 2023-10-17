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
        private readonly IUserServiceAsync _userService;
        private readonly IMapper _mapper;

        public UsersController (IUserServiceAsync userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost(nameof(LoginUserAsync))]
        public async Task<IActionResult> LoginUserAsync([FromQuery] UpSertUserDTO user)
        {
            var receivedUser = (await _userService.LoginUserAsync(_mapper.Map<UpSertUserModel>(user))).FirstOrDefault();

            if (receivedUser != null)
            {
                return Ok(receivedUser);
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
