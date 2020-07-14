using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class ChallengeMap : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder
                .ToTable("challenge");

            builder
                .HasKey(x => x.Id)
                .HasName("id");

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Slug)
                .HasColumnName("slug")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Created_At)
                .HasColumnName("created_at")
                .IsRequired();

            builder
                .HasMany(x => x.Submissions)
                .WithOne(x => x.Challenge)
                .HasForeignKey(x => x.ChallengeId)
                .IsRequired();

            builder
                .HasMany(x => x.Accelerations)
                .WithOne(x => x.Challenge)
                .HasForeignKey(x => x.ChallengeId)
                .IsRequired();

        }
    }
}
