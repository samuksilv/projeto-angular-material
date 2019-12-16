using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Models;

namespace Portal.Infra.Database.mapings {
    public class AddressMap : IEntityTypeConfiguration<Address> {
        public void Configure (EntityTypeBuilder<Address> builder) {

            builder.HasKey (x => x.Id)
                .HasName ("PK_Address");

            builder.Property (x => x.Id)
                .HasColumnType ("UNIQUEIDENTIFIER")
                .IsRequired ();

            builder.Property (x => x.CreatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.UpdatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.Street)
                .HasColumnType ("NVARCHAR(500)")
                .HasMaxLength (500)
                .IsRequired ();

            builder.Property (x => x.City)
                .HasColumnType ("NVARCHAR(500)")
                .HasMaxLength (500)
                .IsRequired ();

            builder.Property (x => x.Complement)
                .HasColumnType ("NVARCHAR(500)")
                .HasMaxLength (500)
                .IsRequired ();

            builder.Property (x => x.Neighborhood)
                .HasColumnType ("NVARCHAR(500)")
                .HasMaxLength (500)
                .IsRequired ();

            builder.Property (x => x.UF)
                .HasColumnType ("NVARCHAR(2)")
                .HasMaxLength (2)
                .IsRequired ();

            builder.Property (x => x.Number)
                .HasColumnType ("INT")
                .IsRequired ();
        }
    }
}