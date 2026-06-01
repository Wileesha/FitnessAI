using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.DTOs;
using FitnessAI.Core.Interfaces;
using FitnessAI.Core.Entities;
using FitnessAI.Infrastructure.Data;

namespace FitnessAI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly FitnessDbContext _context;
        public UserService(FitnessDbContext context)
        {
            _context = context;
        }
        public List<GetUserDto> GetAllUsers()
        {
            return _context.Users.Select(u => new GetUserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }
        public GetUserDto GetUserById(int id)
        {
           var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null) return null;
            return new GetUserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email
            };

        }
        public void CreateUser(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password, 
                CreatedDate = DateTime.UtcNow
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(int id, UpdateUserDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null) return;
            user.Name = dto.Name;
            user.Email = dto.Email;
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null) return;
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
