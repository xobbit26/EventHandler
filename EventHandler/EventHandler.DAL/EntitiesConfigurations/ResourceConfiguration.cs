using EventHandler.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHandler.DAL.EntitiesConfigurations
{
    class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("resource");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.Locale })
                .IsUnique();

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Locale)
                .HasColumnName("locale")
                .IsRequired();

            builder.Property(x => x.Text)
                .HasColumnName("text")
                .IsRequired();
        }
    }
}
