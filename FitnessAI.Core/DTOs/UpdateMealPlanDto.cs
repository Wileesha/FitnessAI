using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class UpdateMealPlanDto
    {
        public string MealName { get; set; }

        public int Calories { get; set; }

        public string MealType { get; set; }
    }
}
