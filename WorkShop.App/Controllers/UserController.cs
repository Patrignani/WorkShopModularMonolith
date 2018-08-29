using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkShop.Domain.Chat.ENUM;
using WorkShop.Domain.Chat.Event;
using WorkShop.Domain.Client.Event;
using WorkShop.Domain.Core.Models;

namespace WorkShop.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ResultModel<Domain.Client.DTO.User> _object;
        private UserEvents _userRepository;
        private UserLoggedEvent _userLoggedEvent;
        private GroupUserEvent _groupUserEvent;
        private GroupEvent _groupEvent;


        public UserController(UserEvents UserRepository,
        GroupUserEvent groupUserEvent, 
        UserLoggedEvent userLoggedEvent,
        GroupEvent groupEvent)
        {
            _groupEvent = groupEvent;
            _userRepository = UserRepository;
            _groupUserEvent = groupUserEvent;
            _userLoggedEvent = userLoggedEvent;
            _object = new ResultModel<Domain.Client.DTO.User>();
        }
        // GET api/values
        [HttpPost]
        public async Task<ActionResult<ResultModel<Domain.Client.DTO.User>>> PostAsync([FromBody]Domain.Client.DTO.User user)
        {
            _object = await _userRepository.Insert(user);
            if(_object.Sucess)
            {
               var groupPublic = await _groupEvent.GetPublicGroup();

                var groupUser = new Domain.Chat.DTO.GroupUser()
                {
                    UserId =user.Id,
                    GroupId = groupPublic.Id

                };

              var obj =  await  _groupUserEvent.Insert(groupUser);
              
              if(!obj.Sucess)
              {
                  await  _userRepository.Remove(user.Id);
                  _object.Sucess = false;
                  _object.Message = new List<string>();
                  _object.Message .Add("Erro: não foi possível realizar o cadastro. Entre em contato com o admonisrador do sistema!");
              }
              
            }

            return _object;
        }

        [HttpGet]
        public async Task<ActionResult<string[]>> GetAsync()
        {
            var user = new Domain.Client.DTO.User() { Identification="Anderson8", Password="123456"};
            // _object = await _userRepository.Insert(user);

            // return _object.Message.ToArray();

             _object = await _userRepository.Login(user.Identification, user.Password);
           if(_object.Sucess)
           {
              var userLoggedDTO = new WorkShop.Domain.Client.DTO.UserLogged()
              {
                  UserId = _object.Object.Id,
                  DataLogged = DateTime.UtcNow
              };
              await  _userLoggedEvent.PingAsync(userLoggedDTO);
           }

            return  Ok(_object.Message.ToArray());
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ResultModel<Domain.Client.DTO.UserLogged>>> LoginAsync([FromBody]Domain.Client.DTO.User user)
        {
            var objetc = new ResultModel<Domain.Client.DTO.UserLogged>();
            _object = await _userRepository.Login(user.Identification, user.Password);
           if(_object.Sucess)
           {
              var userLoggedDTO = new WorkShop.Domain.Client.DTO.UserLogged()
              {
                  UserId = _object.Object.Id,
                  DataLogged = DateTime.UtcNow
              };
              await  _userLoggedEvent.CreateSession(userLoggedDTO);
              objetc.Sucess = true;
              objetc.Object = userLoggedDTO;
           }
           else
           {
                objetc.Sucess = false;
           }

             objetc.Message.AddRange(_object.Message);

            return objetc;
        }
    }
}