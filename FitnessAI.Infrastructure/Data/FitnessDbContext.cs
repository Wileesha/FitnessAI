using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessAI.Infrastructure.Data
{
    public class FitnessDbContext:DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

    }
}
