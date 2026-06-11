using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class DailyCaloriesDto
    {
        public decimal Weight { get; set; }

        public decimal HeightCm { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Goal { get; set; }

        public decimal DailyCalories { get; set; }
    }
}
