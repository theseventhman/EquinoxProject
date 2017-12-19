using System.Collections.Generic;
using System.Security.Claims;

namespace Equinox.Domain.Core.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
