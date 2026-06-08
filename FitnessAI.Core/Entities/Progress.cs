using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAI.Core.Entities;

namespace FitnessAI.Core.Entities
{
    public class Progress
    {
        public int ProgressId { get; set; }

        public int UserId { get; set; }

        public decimal Weight { get; set; }

        public decimal BodyFatPercentage { get; set; }

        public DateTime RecordedDate { get; set; }

        public User User { get; set; }
    }
}
