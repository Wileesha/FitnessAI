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
    public class MealPlanService : IMealPlanService
    {
        private readonly FitnessDbContext _context;
        public MealPlanService(FitnessDbContext context)
        {
            _context = context;
        }
        public void CreateMealPlan(CreateMealPlanDto dto)
        {
            var mealPlan = new MealPlan
            {
                UserId = dto.UserId,
                MealName = dto.MealName,
                Calories = dto.Calories,
                MealType = dto.MealType
            };
            _context.MealPlans.Add(mealPlan);
            _context.SaveChanges();
        }
        public List<GetMealPlanDto> GetAllMealPlans()
        {
            return _context.MealPlans
                .Include(x => x.User)
                .Select(x => new GetMealPlanDto
                {
                    MealPlanId = x.MealPlanId,
                    UserId = x.UserId,
                    MealName = x.MealName,
                    Calories = x.Calories,
                    MealType = x.MealType,
                    CreatedDate = x.CreatedDate
                })
                .ToList();
        }
        public GetMealPlanDto GetMealPlanById(int id)
        {
            return _context.MealPlans
                .Where(x => x.MealPlanId == id)
                .Select(x => new GetMealPlanDto
                {
                    MealPlanId = x.MealPlanId,
                    UserId = x.UserId,
                    MealName = x.MealName,
                    Calories = x.Calories,
                    MealType = x.MealType,
                    CreatedDate = x.CreatedDate
                })
                .FirstOrDefault();
        }
        public void UpdateMealPlan(int id, UpdateMealPlanDto dto)
        {
            var mealPlan = _context.MealPlans
                .FirstOrDefault(x => x.MealPlanId == id);

            if (mealPlan == null)
            {
                throw new Exception("Meal Plan not found");
            }

            mealPlan.MealName = dto.MealName;
            mealPlan.Calories = dto.Calories;
            mealPlan.MealType = dto.MealType;

            _context.SaveChanges();
        }
        public void DeleteMealPlan(int id)
        {
            var mealPlan = _context.MealPlans
                .FirstOrDefault(x => x.MealPlanId == id);

            if (mealPlan == null)
            {
                throw new Exception("Meal Plan not found");
            }

            _context.MealPlans.Remove(mealPlan);

            _context.SaveChanges();
        }


    }
}
