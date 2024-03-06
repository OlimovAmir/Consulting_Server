using Consulting_Server.Models.BaseModels;

namespace Consulting_Server.Repositories
{
    public interface IPostgreSQLRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(Guid id);
    }
}
