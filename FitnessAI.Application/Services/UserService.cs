using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.DTOs;
using FitnessAI.Core.Interfaces;
using FitnessAI.Core.Entities;
using FitnessAI.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;

namespace FitnessAI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly FitnessDbContext _context;
        private readonly IConfiguration _configuration;
        public UserService(FitnessDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
            var existingUser = _context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
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
        public string Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
                return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
                return null;

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
