using System;
using System.ComponentModel.DataAnnotations;

namespace Source.DTOs
{
    public class SubmissionDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ChallengeId { get; set; }
        [Required]
        public decimal Score { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}