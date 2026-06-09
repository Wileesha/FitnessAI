using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class NutritionRecommendationDto
    {
        public decimal Weight { get; set; }

        public string Goal { get; set; }

        public int RecommendedCalories { get; set; }

        public string Recommendation { get; set; }
    }
}
