using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using _.Data.Admin;
using _.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace _.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPost("changerole")]
        public async Task<IActionResult> ChangeRole(ChangeRoleDto changeRoleDto)
        {
            changeRoleDto.Username = changeRoleDto.Username.ToLower();
            
            var user = await _userRepo.ChangeUserRole(changeRoleDto.Username, changeRoleDto.Role);
            if (user == null)
            {
                return BadRequest();
            }
            
            var userToReturn = _mapper.Map<UserDetailedDto>(user);
 
            return Ok(userToReturn);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepo.AllUsers();
            
            var userToReturn = _mapper.Map<IEnumerable<UserDetailedDto>>(users);
            
            

            return Ok(userToReturn);
        }

        [HttpPost("deleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserDto deleteUserDto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Console.WriteLine(userId);
            
            var user = await _userRepo.DeleteUser(deleteUserDto.Username.ToLower());

            if (user)
            {
                return Ok(true);
            }

            return BadRequest(false);
        }
    }
}