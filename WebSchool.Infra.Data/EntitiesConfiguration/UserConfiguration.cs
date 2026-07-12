using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(u => u.PasswordSalt)
                .IsRequired();
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.Property(u => u.Profile)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
