using EventHandler.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHandler.DAL.EntitiesConfigurations
{
    class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(x => x.Applicant)
                .HasColumnName("applicant")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.ApplyDateTime)
                .HasColumnName("apply_date_time")
                .IsRequired();

            builder.Property(x => x.Responsible)
                .HasColumnName("responsible")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Resolver)
                .HasColumnName("resolver")
                .HasMaxLength(250);

            builder.Property(x => x.ResolveDateTime)
                .HasColumnName("resolve_date_time");

            builder.Property(x => x.Notes)
                .HasColumnName("notes");

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .HasMaxLength(250);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);

            builder.Property(x => x.Status).HasColumnName("status").HasMaxLength(250);
        }
    }
}
