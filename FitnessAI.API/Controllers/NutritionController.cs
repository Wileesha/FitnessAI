using Microsoft.AspNetCore.Mvc;
using FitnessAI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FitnessAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NutritionController : ControllerBase
    {
        private readonly INutritionService _nutritionService;

        public NutritionController(
            INutritionService nutritionService)
        {
            _nutritionService = nutritionService;
        }

        [HttpGet("recommendation")]
        public IActionResult GetRecommendation(
            decimal weight,
            string goal)
        {
            var result =
                _nutritionService.GetRecommendation(
                    weight,
                    goal);

            return Ok(result);
        }
    }
}
