using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Infra.Data.EntitiesConfiguration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.TuitionId)
                .IsRequired();
            builder.Property(n => n.NoteValue)
                .IsRequired();

            builder.HasOne(x => x.Tuition)
               .WithMany(x => x.Notes)
               .HasForeignKey(x => x.TuitionId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
