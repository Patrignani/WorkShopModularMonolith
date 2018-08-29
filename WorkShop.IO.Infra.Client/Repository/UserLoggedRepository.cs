using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkShop.Client;
using WorkShop.Client.Interface;
using WorkShop.IO.Infra.Client.Context;

namespace WorkShop.IO.Infra.Client.Repository
{
    public class UserLoggedRepository : IUserLoggedRepository
    {
        private UserContext _userContext;

        public UserLoggedRepository (UserContext userContext)
        {
         _userContext=userContext;
        }

        public void Add(UserLogged obj)
        {
            _userContext.UserLogged.Add(obj);
        }

        public Task<bool> CheckExistItem(UserLogged obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           _userContext.Dispose();
        }

        public async Task<IEnumerable<UserLogged>> FindAsync(Expression<Func<UserLogged, bool>> predicate)
        {
           return await _userContext.UserLogged.AsNoTracking().Where(predicate).ToListAsync();
        }

        public Task<IEnumerable<UserLogged>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserLogged> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
           var remove = await _userContext.UserLogged.FindAsync(id);
           _userContext.UserLogged.Remove(remove);
        }

        public async Task SaveChangesAsync()
        {
            await _userContext.SaveChangesAsync();
        }

        public void Update(UserLogged obj)
        {
            _userContext.Update(obj);
        }
    }
}