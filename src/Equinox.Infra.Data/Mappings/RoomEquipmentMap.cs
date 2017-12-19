using Equinox.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinox.Infra.Data.Mappings
{
    // TODO: That is not the best design but the Many2Many works only with this workaround
    // https://github.com/aspnet/EntityFrameworkCore/issues/1368
    public class RoomEquipmentMap : IEntityTypeConfiguration<RoomEquipment>
    {
        public void Configure(EntityTypeBuilder<RoomEquipment> builder)
        {
            builder.HasKey(re => new {re.RoomId, re.EquipmentId});

            builder.HasOne(re => re.Room)
                .WithMany(r => r.Equipments)
                .HasForeignKey(re => re.RoomId);

            builder.HasOne(re => re.Equipment)
                .WithMany(r => r.Rooms)
                .HasForeignKey(re => re.EquipmentId);

            builder.ToTable("RoomEquipment");
        }
    }
}