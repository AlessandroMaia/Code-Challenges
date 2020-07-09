using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Source.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key, Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("name"), MaxLength(100)]
        public string Name { get; set; }

        [Required, Column("slug"), MaxLength(50)]
        public string Slug { get; set; }

        [Required, Column("challenge_id"), ForeignKey("ChallengeId")]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }

        [Required, Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}
