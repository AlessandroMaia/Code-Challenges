using System;
using System.ComponentModel.DataAnnotations;

namespace Source.DTOs
{
    public class ChallengeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}