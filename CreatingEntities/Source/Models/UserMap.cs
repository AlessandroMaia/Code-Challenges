using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder
                .HasKey(x => x.Id)
                .HasName("id");

            builder
                .Property(x => x.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Nickname)
                .HasColumnName("nickname")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder
                .HasMany(x => x.Submissions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder
                .HasMany(x => x.Candidates)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
                
        }
    }
}
