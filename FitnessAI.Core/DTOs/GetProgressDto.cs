using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class GetProgressDto
    {
        public int ProgressId { get; set; }

        public int UserId { get; set; }

        public decimal Weight { get; set; }

        public decimal BodyFatPercentage { get; set; }

        public DateTime RecordedDate { get; set; }
    }
}
