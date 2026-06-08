using FitnessAI.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.Interfaces
{
    public interface IProgressService
    {
        void CreateProgress(CreateProgressDto dto);

        List<GetProgressDto> GetAllProgress();

        GetProgressDto GetProgressById(int id);

        void DeleteProgress(int id);
    }
}
