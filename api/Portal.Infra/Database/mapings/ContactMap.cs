using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Domain.Enums;
using Portal.Domain.Models;

namespace Portal.Infra.Database.mapings {
    public class ContactMap : IEntityTypeConfiguration<Contact> {
        public void Configure (EntityTypeBuilder<Contact> builder) {
            
            builder.HasKey (x => x.Id)
                .HasName ("PK_Contact");

            builder.Property (x => x.Id)
                .HasColumnType ("UNIQUEIDENTIFIER")
                .IsRequired ();

            builder.Property (x => x.CreatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.UpdatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.ContactType)
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .HasConversion (new EnumToStringConverter<ContactTypeEnum> ());

            builder.Property(x=> x.ContactValue)
                .HasColumnType("NVARCHAR(200)")
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(x=> x.CompanyId)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();
            
            builder
                .HasOne(x=> x.Company)
                .WithMany(x=> x.Contacts)
                .HasConstraintName("Fk_Contact_Company");            
        }
    }
}