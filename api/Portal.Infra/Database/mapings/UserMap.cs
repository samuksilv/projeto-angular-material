using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Models;

namespace Portal.Infra.Database.mapings {
    public class UserMap : IEntityTypeConfiguration<User> {
        public void Configure (EntityTypeBuilder<User> builder) {

            builder.HasKey (x => x.Id)
                .HasName ("PK_User");

            builder.Property (x => x.Id)
                .HasColumnType ("UNIQUEIDENTIFIER")
                .IsRequired ();

            builder.Property (x => x.CreatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.UpdatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.FirstName)
                .IsRequired ()
                .HasColumnType ("NVARCHAR(50)")
                .HasMaxLength (50);

            builder.Property (x => x.LastName)
                .IsRequired ()
                .HasColumnType ("NVARCHAR(300)")
                .HasMaxLength (300);

            builder.Property (x => x.Email)
                .IsRequired ()
                .HasColumnType ("NVARCHAR(300)")                
                .HasMaxLength (300);

            builder.HasIndex(x=> x.Email)
                .IsUnique();

            builder.Property (x => x.Password)
                .IsRequired ()
                .HasColumnType ("NVARCHAR(100)")
                .HasMaxLength (100);

            builder.Property (x => x.BirthDate)
                .HasColumnType ("DateTime2(7)")
                .IsRequired ();
        }
    }
}