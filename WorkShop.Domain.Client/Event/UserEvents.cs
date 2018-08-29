using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tango.Types;
using WorkShop.Client;
using WorkShop.Client.Interface;
using WorkShop.Domain.Core.Events;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Domain.Client.Event
{
    public class UserEvents : Event<Domain.Client.DTO.User>
    {

        private IUserRepository _IUserRepository;
        public UserEvents(IUserRepository iUserRepository)
        {
            _IUserRepository = iUserRepository;
        }


        public async Task<ResultModel<Domain.Client.DTO.User>> Login(string userName, string passWord)
        {
            var user = new User(userName, passWord);
            user = await _IUserRepository.LoginAsync(user);

            if(user !=null)
            {
                Object.Object = new Domain.Client.DTO.User()
                {
                    Id = user.Id,
                    Identification = user.Identification,
                    Password = user.Password,
                };

                Object.Sucess = true;
                Object.Message.Add("Login realizado com sucesso!");
            }
            else
            {
                Object.Sucess = false;
                Object.Message.Add("Login ou senha incorretos!");
            }
            return Object;
        }

        public async Task<ResultModel<Domain.Client.DTO.User>> Insert(Domain.Client.DTO.User user)
        {
            var newUSer = new User(user.Identification, user.Password);
            await SetValidateObject<User>(new string[1] { "Usuário Cadastrado" }, newUSer, user);

            if (Object.Sucess)
            {
                if (!await _IUserRepository.CheckExistItem(newUSer))
                {
                    _IUserRepository.Add(newUSer);
                    await _IUserRepository.SaveChangesAsync();
                    user.Id = newUSer.Id;
                    user.Password = null;
                    SetObject(user);
                }
                else {
                    Object.Sucess = false;
                    Object.Message = new List<string>() { "Usuário já existe" };
                    Object.Object = null;
                }
            }

            return Object;
        }

        public async Task Remove(Guid id)
        {
           await _IUserRepository.Remove(id);
           await _IUserRepository.SaveChangesAsync();
        }

     
    }
}