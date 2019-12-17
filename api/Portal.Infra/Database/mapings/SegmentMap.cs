using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Models;

namespace Portal.Infra.Database.mapings {
    public class SegmentMap : IEntityTypeConfiguration<Segment> {
        public void Configure (EntityTypeBuilder<Segment> builder) {
            builder.HasKey (x => x.Id)
                .HasName ("PK_Segment");

            builder.Property (x => x.Id)
                .HasColumnType ("UNIQUEIDENTIFIER")
                .IsRequired ();

            builder.Property (x => x.CreatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.UpdatedAt)
                .HasColumnType ("DateTime2(7)");

            builder.Property (x => x.Description)
                .HasColumnType ("NVARCHAR(100)")
                .HasMaxLength (100)
                .IsRequired ();

            builder.HasIndex (x => x.Description)
                .IsUnique ();

        }
    }
}