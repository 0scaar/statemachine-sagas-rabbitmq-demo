using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Map
{
    internal class FileDetailConfiguration : IEntityTypeConfiguration<FileDetail>
    {
        public void Configure(EntityTypeBuilder<FileDetail> builder)
        {
            builder.ToTable("FileDetail", "SagaDemo");
            builder.HasKey(d => d.Id);

            builder.Property(o => o.FileId)
                .IsRequired();

            builder.Property(c => c.StoreName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(o => o.File)
                .WithMany(m => m.FileDetails)
                .HasForeignKey(o => o.FileId);
        }
    }
}
