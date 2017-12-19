using System;
using System.Collections.Generic;
using Equinox.Domain.Bookings;
using Equinox.Domain.Core.Models;

namespace Equinox.Domain.Customers
{
    public class Customer : Entity
    {
        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        // EF Relations
        public ICollection<Booking> Bookings { get; set; }
    }
}