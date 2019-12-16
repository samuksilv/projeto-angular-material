using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Models;

namespace Portal.Infra.Database.mapings {
    public class CompanyMap : IEntityTypeConfiguration<Company> {
        public void Configure (EntityTypeBuilder<Company> builder) {

            builder.HasKey (x => x.Id)
                .HasName ("PK_Company");

            builder.Property (x => x.Id)
                .HasColumnType ("UNIQUEIDENTIFIER")
                .IsRequired ();

            builder.Property (x => x.CreatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.UpdatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.DocumentCnpj)
                .HasColumnType ("NVARCHAR(14)")
                .HasMaxLength (14)
                .IsRequired ();

            builder.Property (x => x.CorporateName)
                .HasColumnType ("NVARCHAR(200)")
                .HasMaxLength (200)
                .IsRequired ();

            builder.Property (x => x.FantasyName)
                .HasColumnType ("NVARCHAR(200)")
                .HasMaxLength (200)
                .IsRequired ();

            builder.Property (x => x.CompanyLogoId)
                .IsRequired ()
                .HasColumnType ("UNIQUEIDENTIFIER");

            builder.Property (x => x.SegmentId)
                .IsRequired ()
                .HasColumnType ("UNIQUEIDENTIFIER");

            builder.Property (x => x.AddressId)
                .IsRequired ()
                .HasColumnType ("UNIQUEIDENTIFIER");

            builder
                .HasOne (x => x.CompanyLogo)
                .WithOne (x => x.Company)
                .HasConstraintName ("FK_Company_CompanyLogo")
                .IsRequired ();

            builder
                .HasOne (x => x.Segment)
                .WithMany (x => x.Companies)
                .HasConstraintName ("FK_Company_Segment")
                .IsRequired ();

            builder.HasOne (x => x.Address)
                .WithOne (x => x.Company)
                .HasConstraintName ("FK_Address_Company")
                .IsRequired ();

        }
    }
}