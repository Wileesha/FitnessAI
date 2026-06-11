using FitnessAI.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.Interfaces
{
    public interface INutritionService
    {
        NutritionRecommendationDto GetRecommendation(
            decimal weight,
            string goal);
        BmiResultDto CalculateBmi(
    decimal weight,
    decimal heightCm);
        DailyCaloriesDto CalculateDailyCalories(
    decimal weight,
    decimal heightCm,
    int age,
    string gender,
    string goal);
    }
}
