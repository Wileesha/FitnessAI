using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class GetWorkoutPlanDto
    {
        public int WorkoutPlanId { get; set; }

        public int UserId { get; set; }

        public string WorkoutName { get; set; }

        public string Goal { get; set; }

        public int DurationInWeeks { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
