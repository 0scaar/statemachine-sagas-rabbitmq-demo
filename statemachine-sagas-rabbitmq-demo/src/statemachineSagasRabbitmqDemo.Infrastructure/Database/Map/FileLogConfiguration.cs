using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Map
{
    public class FileLogConfiguration : IEntityTypeConfiguration<FileLog>
    {
        public void Configure(EntityTypeBuilder<FileLog> builder)
        {
            builder.ToTable("FileLog", "SagaDemo");
            builder.HasKey(d => d.Id);

            builder.Property(o => o.FileId)
                .IsRequired();

            builder.Property(c => c.DateLog)
                .IsRequired();

            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Error)
                .HasMaxLength(4000);

            builder.HasOne(o => o.File)
                .WithMany(m => m.FileLogs)
                .HasForeignKey(o => o.FileId);
        }
    }
}
