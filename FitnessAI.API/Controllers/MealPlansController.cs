
using FitnessAI.Core.DTOs;
using FitnessAI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MealPlansController : ControllerBase
    {

        private readonly IMealPlanService _mealPlanService;

        public MealPlansController(IMealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        [HttpPost]
        public IActionResult CreateMealPlan(CreateMealPlanDto dto)
        {
            _mealPlanService.CreateMealPlan(dto);

            return Ok("Meal Plan Created Successfully");
        }

        [HttpGet]
        public IActionResult GetAllMealPlans()
        {
            return Ok(_mealPlanService.GetAllMealPlans());
        }

        [HttpGet("{id}")]
        public IActionResult GetMealPlanById(int id)
        {
            return Ok(_mealPlanService.GetMealPlanById(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMealPlan(int id, UpdateMealPlanDto dto)
        {
            _mealPlanService.UpdateMealPlan(id, dto);

            return Ok("Meal Plan Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMealPlan(int id)
        {
            _mealPlanService.DeleteMealPlan(id);

            return Ok("Meal Plan Deleted Successfully");
        }
    }
}
