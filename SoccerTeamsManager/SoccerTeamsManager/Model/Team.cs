using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerTeamsManager.Model
{
    public class Team
    {
        public Team()
        {
            IdCaptain = null;
        }

        public long Id { get; set; }
        public long? IdCaptain { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }

    }
}
