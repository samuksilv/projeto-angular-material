using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Models;

namespace Portal.Infra.Database.mapings {
    public class CompanyLogoMap : IEntityTypeConfiguration<CompanyLogo> {
        public void Configure (EntityTypeBuilder<CompanyLogo> builder) {
            
            builder.HasKey (x => x.Id)
                .HasName ("PK_Companylogo");

            builder.Property (x => x.Id)
                .HasColumnType ("UNIQUEIDENTIFIER")
                .IsRequired ();

            builder.Property (x => x.CreatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.UpdatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property(x=> x.Logo)
                .HasColumnType("VARBINARY(MAX)")
                .IsRequired();
        }
    }
}