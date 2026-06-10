using FitnessAI.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.Interfaces
{
    public interface IUserProfileService
    {
        void CreateProfile(CreateUserProfileDto dto);

        List<GetUserProfileDto> GetAllProfiles();

        GetUserProfileDto GetProfileById(int id);
    }
}
