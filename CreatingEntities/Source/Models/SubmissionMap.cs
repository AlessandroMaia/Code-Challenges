using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class SubmissionMap : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("submission");

            builder
                .HasKey(x => new { x.UserId, x.ChallengeId });

            builder
                .Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder
                .Property(x => x.ChallengeId)
                .HasColumnName("challenge_id")
                .IsRequired();

            builder
                .Property(x => x.Score)
                .HasColumnName("score")
                .IsRequired();

            builder
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired(); 
        }
    }
}