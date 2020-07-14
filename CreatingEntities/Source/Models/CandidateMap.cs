using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class CandidateMap : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("candidate");

            builder
                .HasKey(x => new { x.UserId, x.AccelerationId, x.CompanyId });

            builder
                .Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder
                .Property(x => x.AccelerationId)
                .HasColumnName("acceleration_id")
                .IsRequired();

            builder
                .Property(x => x.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            builder
                .Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();

            builder
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
