using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Infra.Data.EntitiesConfiguration
{
    public class TuitionConfiguration : IEntityTypeConfiguration<Tuition>
    {
        public void Configure(EntityTypeBuilder<Tuition> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.UserId)
                .IsRequired();
            builder.Property(t => t.SchoolClassId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Tuitions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SchoolClass)
                .WithMany(x => x.Tuitions)
                .HasForeignKey(x => x.SchoolClassId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
