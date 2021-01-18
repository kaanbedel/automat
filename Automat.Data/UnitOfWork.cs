using Microsoft.EntityFrameworkCore;
 
namespace Automat.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
