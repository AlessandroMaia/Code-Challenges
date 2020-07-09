using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("user")]
    public class User
    {
        [Key, Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("full_name"), MaxLength(100)]
        public string FullName { get; set; }

        [Required, Column("email"), MaxLength(100)]
        public string Email { get; set; }

        [Required, Column("nickname"), MaxLength(50)]
        public string Nickname { get; set; }

        [Required, Column("password"), MaxLength(255)]
        public string Password { get; set; }

        [Required, Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}
