using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class CreateProgressDto
    {
        [Required]
        public int UserId { get; set; }

        [Range(20, 300)]
        public decimal Weight { get; set; }

        [Range(1, 100)]
        public decimal BodyFatPercentage { get; set; }
    }
}
