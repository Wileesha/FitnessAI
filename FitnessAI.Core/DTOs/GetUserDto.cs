using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAI.Core.DTOs
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
    }
}
