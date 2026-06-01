
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.DTOs;

namespace FitnessAI.Core.Interfaces
{
    public interface IUserService
    {
        List<GetUserDto> GetAllUsers();
        GetUserDto GetUserById(int id);
        void CreateUser(CreateUserDto user);
        void UpdateUser(int id, UpdateUserDto user);
        void DeleteUser(int id);
    }
}
