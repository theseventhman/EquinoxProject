using System;
using System.Linq;
using Equinox.Domain.Core.Models;
using Equinox.Domain.Customers;

namespace Equinox.Domain.Bookings
{
    public class Booking : Entity
    {
        public BookingPeriod BookingPeriod { get; private set; }
        public Room Room { get; private set; }
        public decimal Price { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid RoomId { get; private set; }

        internal Booking(BookingPeriod bookingPeriod, Room room, Guid ownerId)
        {
            Room = room;
            OwnerId = ownerId;
            BookingPeriod = bookingPeriod;
            RoomId = room.Id;
            Price = GetFullPrice();
        }

        // EF Blank Constructor
        protected Booking(){}

        // EF Navigation Properties
        public virtual Customer Customer { get; protected set; }

        public static Booking Create(BookingPeriod bookingPeriod, Room room, Guid OwnerId)
        {
            if (!room.IsAvailable(bookingPeriod))
                throw new Exception("NAOOOOOOOO");

            var booking = new Booking(bookingPeriod, room, OwnerId);
            return booking;
        }

        private decimal GetFullPrice()
        {
            return Room.Price + Room.Equipments.Select(e=>e.Equipment).Sum(e => e.Price);
        }
    }
}