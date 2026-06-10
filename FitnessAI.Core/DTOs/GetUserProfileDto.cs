using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class GetUserProfileDto
    {
        public int UserProfileId { get; set; }

        public int UserId { get; set; }

        public int Age { get; set; }

        public decimal HeightCm { get; set; }

        public string Gender { get; set; }

        public string Goal { get; set; }
    }
}
