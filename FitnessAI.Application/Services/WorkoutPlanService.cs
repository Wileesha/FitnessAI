using FitnessAI.Core.DTOs;
using FitnessAI.Core.Entities;
using FitnessAI.Core.Interfaces;
using FitnessAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Application.Services
{

    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly FitnessDbContext _context;
        public WorkoutPlanService(FitnessDbContext context)
        {
            _context = context;
        }
        public void CreateWorkoutPlan(CreateWorkoutPlanDto dto)
        {
            var workoutPlan = new WorkoutPlan
            {
                UserId = dto.UserId,
                WorkoutName = dto.WorkoutName,
                Goal = dto.Goal,
                DurationInWeeks = dto.DurationInWeeks,
                CreatedDate = DateTime.UtcNow
            };

            _context.WorkoutPlans.Add(workoutPlan);

            _context.SaveChanges();
        }
        public List<GetWorkoutPlanDto> GetAllWorkoutPlans()
        {
            return _context.WorkoutPlans
                .Include(x=>x.User)
                .Select(x => new GetWorkoutPlanDto
                {
                    WorkoutPlanId = x.WorkoutPlanId,
                    UserId = x.UserId,
                    WorkoutName = x.WorkoutName,
                    Goal = x.Goal,
                    DurationInWeeks = x.DurationInWeeks,
                    CreatedDate = x.CreatedDate
                })
                .ToList();
        }
        public GetWorkoutPlanDto GetWorkoutPlanById(int id)
        {
            return _context.WorkoutPlans
                .Where(x => x.WorkoutPlanId == id)
                .Select(x => new GetWorkoutPlanDto
                {
                    WorkoutPlanId = x.WorkoutPlanId,
                    UserId = x.UserId,
                    WorkoutName = x.WorkoutName,
                    Goal = x.Goal,
                    DurationInWeeks = x.DurationInWeeks,
                    CreatedDate = x.CreatedDate
                })
                .FirstOrDefault();
        }
        public void UpdateWorkoutPlan(int id, UpdateWorkoutPlanDto dto)
        {
            var workoutPlan = _context.WorkoutPlans.FirstOrDefault(x => x.WorkoutPlanId == id);
            if (workoutPlan == null)
            {
                throw new Exception("Workout Plan not found");
            }
            workoutPlan.WorkoutName = dto.WorkoutName;
            workoutPlan.Goal = dto.Goal;
            workoutPlan.DurationInWeeks = dto.DurationInWeeks;
            _context.SaveChanges();
        }
        public void DeleteWorkoutPlan(int id)
        {
            var workoutPlan = _context.WorkoutPlans.FirstOrDefault(x => x.WorkoutPlanId == id);
            if (workoutPlan == null)
            {
                throw new Exception("Workout Plan not found");
            }
            _context.WorkoutPlans.Remove(workoutPlan);
            _context.SaveChanges();
        }
    }
}
