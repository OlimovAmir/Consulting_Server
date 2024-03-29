﻿using Consulting_Server.Models;
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
            if (string.IsNullOrEmpty(item.TextMessage))
            {
                return "The name cannot be empty";
            }
            else
            {
                _repository.Create(item);
                return $"Created new item with this ID: {item.Id}";
            }
        }

        public string Delete(Guid id)
        {
            var result = _repository.Delete(id);
            if (result)
                return "Item deleted";
            else
                return "Item not found";
        }

        public IQueryable<MessageFromUser> GetAll()
        {
            return _repository.GetAll();
        }

        public MessageFromUser GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public string Update(Guid id, MessageFromUser item)
        {
            var _item = _repository.GetById(id);
            if (_item is not null)
            {
                _item.TextMessage = item.TextMessage;
               

                var result = _repository.Update(_item);
                if (result)
                    return "Item updated";
            }

            return "Item updated";
        }
    }
}
