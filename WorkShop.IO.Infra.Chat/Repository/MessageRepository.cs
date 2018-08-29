using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Chat;
using WorkShop.Domain.Chat.Interface;

namespace WorkShop.IO.Infra.Chat.Repository
{
    public class MessageRepository : IMessage
    {
        public void Add(Message obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckExistItem(Message obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> FindAsync(Expression<Func<Message, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Message obj)
        {
            throw new NotImplementedException();
        }
    }
}
