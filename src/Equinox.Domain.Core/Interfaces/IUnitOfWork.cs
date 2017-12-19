using System;
using Equinox.Domain.Core.Commands;

namespace Equinox.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
