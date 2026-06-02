using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class CreateWorkoutPlanDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string WorkoutName { get; set; }

        [Required]
        public string Goal { get; set; }

        [Range(1, 52)]
        public int DurationInWeeks { get; set; }
    }
}
