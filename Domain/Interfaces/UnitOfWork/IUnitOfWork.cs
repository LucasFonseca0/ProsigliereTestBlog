using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
