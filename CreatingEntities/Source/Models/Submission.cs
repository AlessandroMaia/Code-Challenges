using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class Submission
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
        public decimal Score { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
