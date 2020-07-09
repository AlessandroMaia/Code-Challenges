using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [Key, Required, Column("user_id"), ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key, Required, Column("acceleration_id"), ForeignKey("AccelerationId")]
        public int AccelerationId { get; set; }
        public Acceleration Acceleration { get; set; }

        [Key, Required, Column("company_id"), ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required, Column("status")]
        public int Status { get; set; }

        [Required, Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
