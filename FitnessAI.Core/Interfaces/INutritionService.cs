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
    }
}
