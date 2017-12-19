using System;

namespace Equinox.Domain.Bookings
{
    // TODO: That is not the best design but the Many2Many works only with this workaround
    // https://github.com/aspnet/EntityFrameworkCore/issues/1368

    public class RoomEquipment
    {
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}