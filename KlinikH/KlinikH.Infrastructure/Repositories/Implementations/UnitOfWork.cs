using KlinikH.Infrastructure.Repositories.Interfaces;

namespace KlinikH.Infrastructure.Repositories.Implementations
{
    public class UnitOfWork : UnitOfWorkInterface, IDisposable
    {
        private readonly ApplicationDBContext _context;
        private bool disposed = false;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public GenericRepositoryInterface<T> GenericRepository<T>() where T : class
        {
            GenericRepositoryInterface<T> repo = new GenericRepository<T>(_context);
            return repo;
        }
    }
}
