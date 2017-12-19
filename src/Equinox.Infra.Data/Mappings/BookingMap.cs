using Equinox.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinox.Infra.Data.Mappings
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.OwnsOne(c => c.BookingPeriod, cb =>
            {
                cb.Property(c=>c.Start)
                    .HasColumnName("StartTime")
                    .IsRequired();

                cb.Property(c => c.End)
                    .HasColumnName("EndTime")
                    .IsRequired();
            });

            builder.Property(c => c.Price)
                .IsRequired();

            builder.HasOne(e => e.Room)
                .WithMany(o => o.Bookings)
                .HasForeignKey(e => e.RoomId);

            builder.HasOne(e => e.Customer)
                .WithMany(o => o.Bookings)
                .HasForeignKey(e => e.OwnerId);

            builder.ToTable("Bookings");
        }
    }
}