using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required, Column("name"), MaxLength(100)]
        public string Name { get; set; }

        [Required, Column("slug"), MaxLength(50)]
        public string Slug { get; set; }

        [Required, Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }

    }
}
