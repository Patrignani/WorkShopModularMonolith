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
    public class UserRepository : IUserRepository
    {
    private UserContext _userContext;

    public UserRepository (UserContext userContext)
    {
        _userContext=userContext;
    }

        public void Add(User obj)
        {
           _userContext.User.Add(obj);
        }

        public  Task<bool> CheckExistItem(User obj)
        {
           return  _userContext.User.AnyAsync(x => x.Identification == obj.Identification);
        }

        public void Dispose()
        {
            _userContext.Dispose();
        }

        public  async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
           return  await _userContext.User.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userContext.User.ToListAsync();
        }

        public  Task<User> GetByIdAsync(Guid id)
        {
            return  _userContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public  Task<User> LoginAsync(User obj)
        {
           return  _userContext.User.Where(x => x.Identification == obj.Identification && x.Password == obj.Password).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
           var user = await GetByIdAsync(id);
            _userContext.User.Remove(user);
        }

        public  Task SaveChangesAsync()
        {
            return  _userContext.SaveChangesAsync();
        }

        public void Update(User obj)
        {
            _userContext.User.Update(obj);
        }

    
    }
}