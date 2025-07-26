using KlinikH.Domain.Helpers.Interfaces;
using KlinikH.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KlinikH.Infrastructure.Implementations.Helpers
{
    public class DBInitializer : DBInitializerInterface
    {
        private ApplicationDBContext _context;

        public DBInitializer(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
