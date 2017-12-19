using System.Collections.Generic;
using System.Linq;
using Equinox.Domain.Core.Models;

namespace Equinox.Domain.Bookings
{
    public class Room : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Capacity { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<RoomEquipment> Equipments { get; private set; }
        public ICollection<Booking> Bookings { get; private set; }

        public Room(string name, string description, int capacity, decimal price)
        {
            Name = name;
            Description = description;
            Capacity = capacity;
            Price = price;
        }

        // EF Blank Constructor
        protected Room() { }

        public void AddEquipment(Equipment equipment)
        {
            var roomEquipment = new RoomEquipment
            {
                Room = this,
                RoomId = this.Id,
                Equipment = equipment,
                EquipmentId = equipment.Id
            };

            Equipments.Add(roomEquipment);
        }

        public bool IsAvailable(BookingPeriod requestedBookingPeriod)
        {
            return !Bookings.Any(b => b.BookingPeriod.OverlappedBy(requestedBookingPeriod));
        }
    }
}