using FitnessAI.Core.DTOs;
using FitnessAI.Core.Interfaces;
using FitnessAI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Application.Services
{
    public class DashboardService:IDashboardService
    {
        private readonly FitnessDbContext _context;

        public DashboardService(FitnessDbContext context)
        {
            _context = context;
        }

        public DashboardDto GetDashboard()
        {
            return new DashboardDto
            {
                TotalUsers = _context.Users.Count(),

                TotalWorkoutPlans =
        _context.WorkoutPlans.Count(),

                TotalMealPlans =
        _context.MealPlans.Count(),

                TotalProgressRecords =
        _context.ProgressRecords.Count(),

                AverageWeight =
        _context.ProgressRecords.Any()
        ?
        _context.ProgressRecords.Average(x => x.Weight)
        : 0
            };
        }

    }
}
