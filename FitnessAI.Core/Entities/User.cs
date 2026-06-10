using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<WorkoutPlan> WorkoutPlans { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }
        public ICollection<Progress> ProgressRecords { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
