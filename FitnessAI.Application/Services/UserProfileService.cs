using FitnessAI.Core.DTOs;
using FitnessAI.Core.Entities;
using FitnessAI.Core.Interfaces;
using FitnessAI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Application.Services
{
    public class UserProfileService :IUserProfileService
    {
        private readonly FitnessDbContext _context;

        public UserProfileService(FitnessDbContext context)
        {
            _context = context;
        }
        public void CreateProfile(CreateUserProfileDto dto)
        {
            var profile = new UserProfile
            {
                UserId = dto.UserId,
                Age = dto.Age,
                HeightCm = dto.HeightCm,
                Gender = dto.Gender,
                Goal = dto.Goal
            };

            _context.UserProfiles.Add(profile);

            _context.SaveChanges();
        }
        public List<GetUserProfileDto> GetAllProfiles()
        {
            return _context.UserProfiles
                .Select(x => new GetUserProfileDto
                {
                    UserProfileId = x.UserProfileId,
                    UserId = x.UserId,
                    Age = x.Age,
                    HeightCm = x.HeightCm,
                    Gender = x.Gender,
                    Goal = x.Goal
                })
                .ToList();
        }
        public GetUserProfileDto GetProfileById(int id)
        {
            return _context.UserProfiles
                .Where(x => x.UserProfileId == id)
                .Select(x => new GetUserProfileDto
                {
                    UserProfileId = x.UserProfileId,
                    UserId = x.UserId,
                    Age = x.Age,
                    HeightCm = x.HeightCm,
                    Gender = x.Gender,
                    Goal = x.Goal
                })
                .FirstOrDefault();
        }
    }
}
