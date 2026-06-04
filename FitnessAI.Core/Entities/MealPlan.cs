using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.Entities
{
    public class MealPlan
    {
        public int MealPlanId { get; set; }

        public int UserId { get; set; }

        public string MealName { get; set; }

        public int Calories { get; set; }

        public string MealType { get; set; }

        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
    }
}
