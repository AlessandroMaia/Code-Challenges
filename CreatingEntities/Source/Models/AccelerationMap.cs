using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class AccelerationMap : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> builder)
        {
            builder
                .ToTable("acceleration");

            builder
                .HasKey(x => x.Id)
                .HasName("name");

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
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder
                .Property(x => x.ChallengeId)
                .HasColumnName("challenge_id")
                .IsRequired();

            builder
                .HasMany(x => x.Candidates)
                .WithOne(x => x.Acceleration)
                .HasForeignKey(x => x.AccelerationId)
                .IsRequired();
        }
    }
}
