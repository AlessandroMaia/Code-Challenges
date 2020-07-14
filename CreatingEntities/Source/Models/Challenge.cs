using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime Created_At { get; set; }

        public List<Submission> Submissions { get; set; }
        public List<Acceleration> Accelerations { get; set; }
    }
}
