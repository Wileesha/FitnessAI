using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class CreateMealPlanDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string MealName { get; set; }

        [Range(1, 5000)]
        public int Calories { get; set; }

        [Required]
        public string MealType { get; set; }
    }
}
