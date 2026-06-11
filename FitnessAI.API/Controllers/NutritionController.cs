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
        [HttpGet("bmi")]
        public IActionResult CalculateBmi(
    decimal weight,
    decimal heightCm)
        {
            return Ok(
                _nutritionService.CalculateBmi(
                    weight,
                    heightCm));
        }
        [HttpGet("daily-calories")]
        public IActionResult CalculateDailyCalories(decimal weight, decimal heightCm, int age, string gender, string goal)

        {
            var result =
                _nutritionService
                .CalculateDailyCalories(
                    weight,
                    heightCm,
                    age,
                    gender,
                    goal);

            return Ok(result);
        }
    }
}
