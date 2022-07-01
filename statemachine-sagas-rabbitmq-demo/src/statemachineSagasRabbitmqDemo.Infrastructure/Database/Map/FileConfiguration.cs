using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Map
{
    public class FileConfiguration : IEntityTypeConfiguration<Entity::File>
    {
        public void Configure(EntityTypeBuilder<Entity::File> builder)
        {
            builder.ToTable("File", "SagaDemo");
            builder.HasKey(d => d.Id);

            builder.Property(c => c.FileName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
