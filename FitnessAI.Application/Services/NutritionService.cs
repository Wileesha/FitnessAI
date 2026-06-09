using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.DTOs;
using FitnessAI.Core.Interfaces;

namespace FitnessAI.Application.Services
{
    public class NutritionService : INutritionService
    {
        public NutritionRecommendationDto GetRecommendation(
            decimal weight,
            string goal)
        {
            int calories;
            string recommendation;

            if (goal == "Weight Loss")
            {
                calories = 1800;
                recommendation =
                    "Maintain calorie deficit and high protein intake.";
            }
            else if (goal == "Muscle Gain")
            {
                calories = 2800;
                recommendation =
                    "Increase protein intake and strength training.";
            }
            else
            {
                calories = 2200;
                recommendation =
                    "Maintain balanced nutrition.";
            }

            return new NutritionRecommendationDto
            {
                Weight = weight,
                Goal = goal,
                RecommendedCalories = calories,
                Recommendation = recommendation
            };
        }
    }
}
