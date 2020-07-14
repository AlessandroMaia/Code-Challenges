using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .ToTable("company");

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
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder
                .HasMany(x => x.Candidates)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();

        }
    }
}