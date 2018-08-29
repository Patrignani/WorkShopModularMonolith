using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkShop.Domain.Chat;
using WorkShop.Domain.Chat.Interface;
using WorkShop.Domain.Core.Interfaces;
using WorkShop.IO.Infra.Chat.Context;

namespace WorkShop.IO.Infra.Chat.Repository
{
    public class GroupRepository : IGroup
    {
         private ChatContext _chatContext;

        public GroupRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }
        public void Add(Group obj)
        {
            _chatContext.Add(obj);
        }

        public Task<bool> CheckExistItem(Group obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           _chatContext.Dispose();
        }

        public async Task<IEnumerable<Group>> FindAsync(Expression<Func<Group, bool>> predicate)
        {
            return await _chatContext.Group.Where(predicate).ToListAsync();
        }

        public Task<IEnumerable<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
           await _chatContext.SaveChangesAsync();
        }

        public void Update(Group obj)
        {
            throw new NotImplementedException();
        }
    }
}
