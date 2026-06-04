using FitnessAI.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.Interfaces
{
    public interface IMealPlanService
    {
        void CreateMealPlan(CreateMealPlanDto dto);

        List<GetMealPlanDto> GetAllMealPlans();

        GetMealPlanDto GetMealPlanById(int id);

        void UpdateMealPlan(int id, UpdateMealPlanDto dto);

        void DeleteMealPlan(int id);
    }
}
