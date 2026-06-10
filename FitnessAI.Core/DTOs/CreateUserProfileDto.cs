using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class CreateUserProfileDto
    {
        [Required]
        public int UserId { get; set; }

        [Range(10, 100)]
        public int Age { get; set; }

        [Range(100, 250)]
        public decimal HeightCm { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Goal { get; set; }
    }
}
