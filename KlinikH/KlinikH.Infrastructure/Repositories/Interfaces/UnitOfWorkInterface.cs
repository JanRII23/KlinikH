

namespace KlinikH.Infrastructure.Repositories.Interfaces
{
    public interface UnitOfWorkInterface
    {
        GenericRepositoryInterface<T> GenericRepository<T>() where T : class;
        void Save();
    }
}
