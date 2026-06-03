using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.DTOs;

namespace FitnessAI.Core.Interfaces
{
    public interface IWorkoutPlanService
    {
        void CreateWorkoutPlan(CreateWorkoutPlanDto dto);

        List<GetWorkoutPlanDto> GetAllWorkoutPlans();

        GetWorkoutPlanDto GetWorkoutPlanById(int id);
        void UpdateWorkoutPlan(int id, UpdateWorkoutPlanDto dto);

        void DeleteWorkoutPlan(int id);

    }
}
