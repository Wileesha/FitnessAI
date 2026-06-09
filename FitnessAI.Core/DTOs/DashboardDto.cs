using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class DashboardDto
    {
        public int TotalUsers { get; set; }

        public int TotalWorkoutPlans { get; set; }

        public int TotalMealPlans { get; set; }

        public int TotalProgressRecords { get; set; }
        public decimal AverageWeight { get; set; }
    }
}
