using Consulting_Server.Infrastructure;
using Consulting_Server.Models.BaseModels;

namespace Consulting_Server.Repositories
{
    public class PostgreSQLRepository<T> : IPostgreSQLRepository<T> where T : BaseEntity
    {
        readonly MemoryContext _context;
        public bool Create(T item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
