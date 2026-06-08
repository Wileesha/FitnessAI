using FitnessAI.Core.DTOs;
using FitnessAI.Core.Entities;
using FitnessAI.Infrastructure.Data;
using FitnessAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Application.Services
{
    public class ProgressService: IProgressService
    {
        private readonly FitnessDbContext _context;
        public ProgressService(FitnessDbContext context)
        {
            _context = context;
        }
        public void CreateProgress(CreateProgressDto dto)
        {
            var progress = new Progress
            {
                UserId = dto.UserId,
                Weight = dto.Weight,
                BodyFatPercentage = dto.BodyFatPercentage,
                RecordedDate = DateTime.UtcNow
            };

            _context.ProgressRecords.Add(progress);

            _context.SaveChanges();
        }
        public List<GetProgressDto> GetAllProgress()
        {
            return _context.ProgressRecords
                .Select(x => new GetProgressDto
                {
                    ProgressId = x.ProgressId,
                    UserId = x.UserId,
                    Weight = x.Weight,
                    BodyFatPercentage = x.BodyFatPercentage,
                    RecordedDate = x.RecordedDate
                })
                .ToList();
        }
        public GetProgressDto GetProgressById(int id)
        {
            return _context.ProgressRecords
                .Where(x => x.ProgressId == id)
                .Select(x => new GetProgressDto
                {
                    ProgressId = x.ProgressId,
                    UserId = x.UserId,
                    Weight = x.Weight,
                    BodyFatPercentage = x.BodyFatPercentage,
                    RecordedDate = x.RecordedDate
                })
                .FirstOrDefault();
        }
        public void DeleteProgress(int id)
        {
            var progress = _context.ProgressRecords
                .FirstOrDefault(x => x.ProgressId == id);

            if (progress == null)
            {
                throw new Exception("Progress record not found");
            }

            _context.ProgressRecords.Remove(progress);

            _context.SaveChanges();
        }
    }
}
