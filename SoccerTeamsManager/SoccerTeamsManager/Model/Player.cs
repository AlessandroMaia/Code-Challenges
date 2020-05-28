using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerTeamsManager.Model
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime birthDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }
        public long TeamId { get; set; }
    }
}
