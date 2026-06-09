using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.DTOs;

namespace FitnessAI.Core.Interfaces
{
    public interface IDashboardService
    {
        DashboardDto GetDashboard();
    }
}
