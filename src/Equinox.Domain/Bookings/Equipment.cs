using System.Collections.Generic;
using Equinox.Domain.Core.Models;

namespace Equinox.Domain.Bookings
{
    public class Equipment : Entity
    {
        public string Name { get; private set; }
        public EquipmentType EquipmentType { get; private set; }
        public decimal Price { get; private set; }

        // EF Blank Constructor
        protected Equipment(){}

        // EF Relations - See the comment into RoomEquipment class
        public ICollection<RoomEquipment> Rooms { get; private set; }
    }
}