using System;
using System.Linq;
using System.Threading.Tasks;
using WorkShop.Client;
using WorkShop.Client.Interface;
using WorkShop.Domain.Core.Events;

namespace WorkShop.Domain.Client.Event
{
    public class UserLoggedEvent: Event<Domain.Client.DTO.UserLogged>
    {
         private IUserLoggedRepository _IUserLoggedRepository;
        public UserLoggedEvent(IUserLoggedRepository iUserLoggedRepository)
        {
            _IUserLoggedRepository = iUserLoggedRepository;
        }

        public async Task<bool> UserLogged(string key, Guid id)
        {
            return (await _IUserLoggedRepository.FindAsync(x => x.UserId == id 
            && x.Hash == key)).Any();
        }
        public async Task<WorkShop.Domain.Client.DTO.UserLogged> PingAsync(WorkShop.Domain.Client.DTO.UserLogged userLoggedDTO)
        {
           var checkUserLogged =(await _IUserLoggedRepository.FindAsync(x =>userLoggedDTO.UserId == x.UserId 
            && x.Hash == userLoggedDTO.Hash)).FirstOrDefault();

            UserLogged userLogged = null;
            if(checkUserLogged != null)
            {
                userLogged = checkUserLogged;
                userLogged.SetDataCheck();
                _IUserLoggedRepository.Update(userLogged);

                 await _IUserLoggedRepository.SaveChangesAsync();

                userLoggedDTO.DataCheck = userLogged.DataCheck;
                userLoggedDTO.DataLogged = userLogged.DataLogged;
                userLoggedDTO.Hash = userLogged.Hash;
                userLoggedDTO.Ip = userLogged.Ip;
                userLoggedDTO.UserId = userLogged.UserId;
            }
            else 
            {
              userLoggedDTO = null;
            }
         
            var dateExclud = DateTime.UtcNow.AddSeconds(-300);
            var excluds = await _IUserLoggedRepository.FindAsync(x =>x.DataLogged <= dateExclud);

           foreach(var exclud in excluds)
           {
               await _IUserLoggedRepository.Remove(exclud.Id);
           }

            await _IUserLoggedRepository.SaveChangesAsync();

            return userLoggedDTO;
        }

        public async Task CreateSession(WorkShop.Domain.Client.DTO.UserLogged userLoggedDTO)
        {

                var userLogged= new UserLogged(userLoggedDTO.UserId, 
                userLoggedDTO.DataLogged, 
                userLoggedDTO.Ip);
                _IUserLoggedRepository.Add(userLogged);

                 await _IUserLoggedRepository.SaveChangesAsync();

                userLoggedDTO.DataCheck = userLogged.DataCheck;
                userLoggedDTO.DataLogged = userLogged.DataLogged;
                userLoggedDTO.Hash = userLogged.Hash;
                userLoggedDTO.Ip = userLogged.Ip;
                userLoggedDTO.UserId = userLogged.UserId;
        }

        public async Task Logout(string key, Guid id)
        {
          var  userLogged= (await _IUserLoggedRepository.FindAsync(x => x.UserId == id 
            && x.Hash == key)).FirstOrDefault();

            if(userLogged != null)
            {
                await _IUserLoggedRepository.Remove(userLogged.Id);
                await _IUserLoggedRepository.SaveChangesAsync();
            }

        }
        
    }
}