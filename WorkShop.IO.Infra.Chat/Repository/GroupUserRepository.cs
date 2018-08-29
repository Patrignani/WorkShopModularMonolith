using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Chat;
using WorkShop.Domain.Chat.Interface;
using WorkShop.IO.Infra.Chat.Context;

namespace WorkShop.IO.Infra.Chat.Repository
{
    public class GroupUserRepository : IGroupUser
    {
        private ChatContext _chatContext;

        public GroupUserRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public void Add(GroupUser obj)
        {
            _chatContext.GroupUser.Add(obj);
        }

        public Task<bool> CheckExistItem(GroupUser obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _chatContext.Dispose();
        }

        public async Task<IEnumerable<GroupUser>> FindAsync(Expression<Func<GroupUser, bool>> predicate)
        {
           return await _chatContext.GroupUser.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<GroupUser>> GetAllAsync()
        {
            return await _chatContext.GroupUser.ToListAsync();
        }

        public async Task<GroupUser> GetByIdAsync(Guid id)
        {
            return await _chatContext.GroupUser.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async  Task Remove(Guid id)
        {
           var groupUser =  await GetByIdAsync(id);
            _chatContext.GroupUser.Remove(groupUser);
        }

        public async Task SaveChangesAsync()
        {
          await  _chatContext.SaveChangesAsync();
        }

        public void Update(GroupUser obj)
        {
            _chatContext.GroupUser.Update(obj);
        }
    }
}
