using Microsoft.AspNetCore.Mvc;
using FitnessAI.Infrastructure.Data;
using FitnessAI.Core.Interfaces;
using FitnessAI.Core.DTOs;

namespace FitnessAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly FitnessDbContext _context;
        private readonly IUserService _userService;
        public UsersController(FitnessDbContext context, IUserService userservice)
        {
            _context = context;
            _userService = userservice;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            _userService.CreateUser(dto);
            return Ok("User created successfully!");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UpdateUserDto dto)
        {
            _userService.UpdateUser(id, dto);
            return Ok("User updated successfully!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok("User deleted successfully!");
        }
    }
}
