using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class BmiResultDto
    {
        public decimal Weight { get; set; }

        public decimal HeightCm { get; set; }

        public decimal BMI { get; set; }

        public string Category { get; set; }
    }
}
