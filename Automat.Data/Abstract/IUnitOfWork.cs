using Microsoft.EntityFrameworkCore;
using System;

namespace Automat.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void SaveChanges();
    }
}
