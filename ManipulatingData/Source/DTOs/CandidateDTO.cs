using System;
using System.ComponentModel.DataAnnotations;

namespace Source.DTOs
{
    public class CandidateDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AccelerationId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}