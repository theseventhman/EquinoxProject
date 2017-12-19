using Equinox.Domain.Core.Interfaces;
using Equinox.Domain.Customers;

namespace Equinox.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}