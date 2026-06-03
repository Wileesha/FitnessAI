using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class UpdateWorkoutPlanDto
    {
        public string WorkoutName { get; set; }

        public string Goal { get; set; }

        public int DurationInWeeks { get; set; }
    }
}
