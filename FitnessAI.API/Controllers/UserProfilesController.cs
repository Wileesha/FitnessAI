using FitnessAI.Core.DTOs;
using FitnessAI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfilesController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpPost]
        public IActionResult CreateProfile(CreateUserProfileDto dto)
        {
            _userProfileService.CreateProfile(dto);

            return Ok("Profile created successfully");
        }

        [HttpGet]
        public IActionResult GetAllProfiles()
        {
            var profiles = _userProfileService.GetAllProfiles();

            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfileById(int id)
        {
            var profile = _userProfileService.GetProfileById(id);

            if (profile == null)
            {
                return NotFound("Profile not found");
            }

            return Ok(profile);
        }
    }
}