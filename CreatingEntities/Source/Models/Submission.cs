using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("submission")]
    public class Submission
    {
        [Key, Required, Column("user_id"), ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key, Required, Column("challenge_id"), ForeignKey("ChallengeId")]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }

        [Required, Column("score")]
        public decimal Score { get; set; }

        [Required, Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
