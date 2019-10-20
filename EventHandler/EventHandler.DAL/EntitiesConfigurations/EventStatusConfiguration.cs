using EventHandler.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHandler.DAL.EntitiesConfigurations
{
    class EventStatusConfiguration : IEntityTypeConfiguration<EventStatus>
    {
        public void Configure(EntityTypeBuilder<EventStatus> builder)
        {
            builder.ToTable("event_status");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.SysName)
                .HasColumnName("sys_name")
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired();
        }
    }
}
