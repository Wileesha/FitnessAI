using FitnessAI.Application.Services;
using FitnessAI.Core.DTOs;
using FitnessAI.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FitnessAI.Core.Interfaces;

namespace FitnessAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProgressController : ControllerBase
    {


        private readonly IProgressService _progressService;
        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }
        [HttpPost]
        public IActionResult CreateProgress(CreateProgressDto dto)
        {
            _progressService.CreateProgress(dto);

            return Ok("Progress added successfully");
        }
        [HttpGet]
        public IActionResult GetAllProgress()
        {
            return Ok(_progressService.GetAllProgress());
        }
        [HttpGet("{id}")]
        public IActionResult GetProgressById(int id)
        {
            return Ok(_progressService.GetProgressById(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProgress(int id)
        {
            _progressService.DeleteProgress(id);

            return Ok("Progress deleted successfully");
        }
    }
}
