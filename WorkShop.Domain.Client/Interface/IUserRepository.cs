using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Core.Interfaces;

namespace WorkShop.Client.Interface
{
   public interface  IUserRepository: IRepository<User>
    {
        Task<User> LoginAsync(User obj);
    }
}
