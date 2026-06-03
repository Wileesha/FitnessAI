using Microsoft.AspNetCore.Authorization;
using FitnessAI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FitnessAI.Infrastructure.Data;
using FitnessAI.Core.DTOs;

namespace FitnessAI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly IWorkoutPlanService _workoutPlanService;
        public WorkoutPlansController(IWorkoutPlanService workoutPlanService)
        {
            _workoutPlanService = workoutPlanService;
        }
        [HttpPost]
        public IActionResult CreateWorkoutPlan(CreateWorkoutPlanDto dto)
        {
            _workoutPlanService.CreateWorkoutPlan(dto);

            return Ok("Workout Plan Created Successfully");
        }

        [HttpGet]
        public IActionResult GetAllWorkoutPlans()
        {
            var workoutPlans = _workoutPlanService.GetAllWorkoutPlans();

            return Ok(workoutPlans);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkoutPlanById(int id)
        {
            var workoutPlan = _workoutPlanService.GetWorkoutPlanById(id);

            if (workoutPlan == null)
            {
                return NotFound();
            }

            return Ok(workoutPlan);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateWorkoutPlan(int id, UpdateWorkoutPlanDto dto)
        {
            _workoutPlanService.UpdateWorkoutPlan(id, dto);

            return Ok("Workout Plan Updated Successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkoutPlan(int id)
        {
            _workoutPlanService.DeleteWorkoutPlan(id);

            return Ok("Workout Plan Deleted Successfully");
        }
    }
}
