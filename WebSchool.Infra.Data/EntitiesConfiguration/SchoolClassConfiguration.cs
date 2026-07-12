using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Infra.Data.EntitiesConfiguration
{
    public class SchoolClassConfiguration : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.CourseId)
                .IsRequired();
            builder.Property(sc => sc.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(sc => sc.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(x => x.Course)
               .WithMany(x => x.SchoolClasses)
               .HasForeignKey(x => x.CourseId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
