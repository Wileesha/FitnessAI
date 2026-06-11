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
                    "High protein + calorie deficit";
            }
            else if (goal == "Muscle Gain")
            {
                calories = 2800;

                recommendation =
                    "High protein + strength training";
            }
            else
            {
                calories = 2200;

                recommendation =
                    "Balanced diet";
            }

            return new NutritionRecommendationDto
            {
                Weight = weight,
                Goal = goal,
                RecommendedCalories = calories,
                Recommendation = recommendation
            };
        }
        public BmiResultDto CalculateBmi(
    decimal weight,
    decimal heightCm)
        {
            decimal heightM = heightCm / 100;

            decimal bmi =
                weight /
                (heightM * heightM);

            string category;

            if (bmi < 18.5m)
                category = "Underweight";
            else if (bmi < 25)
                category = "Normal";
            else if (bmi < 30)
                category = "Overweight";
            else
                category = "Obese";

            return new BmiResultDto
            {
                Weight = weight,
                HeightCm = heightCm,
                BMI = Math.Round(bmi, 2),
                Category = category
            };
        }
        public DailyCaloriesDto CalculateDailyCalories(
    decimal weight,
    decimal heightCm,
    int age,
    string gender,
    string goal)
        {
            decimal bmr;

            if (gender == "Male")
            {
                bmr =
                    (10 * weight)
                    +
                    (6.25m * heightCm)
                    -
                    (5 * age)
                    +
                    5;
            }
            else
            {
                bmr =
                    (10 * weight)
                    +
                    (6.25m * heightCm)
                    -
                    (5 * age)
                    -
                    161;
            }

            decimal calories;

            if (goal == "Weight Loss")
            {
                calories = bmr - 500;
            }
            else if (goal == "Muscle Gain")
            {
                calories = bmr + 300;
            }
            else
            {
                calories = bmr;
            }

            return new DailyCaloriesDto
            {
                Weight = weight,
                HeightCm = heightCm,
                Age = age,
                Gender = gender,
                Goal = goal,
                DailyCalories =
                    Math.Round(calories, 2)
            };
        }
    }
}
