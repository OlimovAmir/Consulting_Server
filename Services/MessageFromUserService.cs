using Consulting_Server.Models;
using Consulting_Server.Repositories;

namespace Consulting_Server.Services
{
    public class MessageFromUserService : IMessageFromUserService
    {
        IPostgreSQLRepository<MessageFromUser> _repository;

        public MessageFromUserService(IPostgreSQLRepository<MessageFromUser> repository)
        {
            _repository = repository;
        }
        public string Create(MessageFromUser item)
        {
            throw new NotImplementedException();
        }

        public string Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MessageFromUser> GetAll()
        {
            return _repository.GetAll();
        }

        public MessageFromUser GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(Guid id, MessageFromUser item)
        {
            throw new NotImplementedException();
        }
    }
}
