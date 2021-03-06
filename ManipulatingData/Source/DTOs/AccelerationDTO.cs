using System;
using System.ComponentModel.DataAnnotations;

namespace Source.DTOs
{
    public class AccelerationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public int ChallengeId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}