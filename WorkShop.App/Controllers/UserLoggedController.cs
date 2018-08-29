using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkShop.Domain.Client.Event;
using WorkShop.Domain.Core.Models;

namespace WorkShop.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoggedController: ControllerBase
    {
        private ResultModel<Domain.Client.DTO.UserLogged> _object;
        private UserLoggedEvent _userLoggedEvent;

        public UserLoggedController(UserLoggedEvent userLoggedEvent)
        {
            _userLoggedEvent = userLoggedEvent;
        }

          [HttpGet]
          [Route("UserLogged")]
          public async Task<bool> UserLoggedAsync([FromQuery]string key, [FromQuery] Guid userId)
          {
             return await _userLoggedEvent.UserLogged(key, userId);
          }

          [HttpGet]
          [Route("Ping")]
          public async Task<WorkShop.Domain.Client.DTO.UserLogged> PingAsync([FromQuery]string key, [FromQuery] Guid userId)
          {
             var userLogged = new WorkShop.Domain.Client.DTO.UserLogged()
             {
                 Hash =key,
                 UserId = userId
             };
            return await _userLoggedEvent.PingAsync(userLogged);
              
          }

            [HttpGet]
          [Route("Logout")]
          public async Task Logout([FromQuery]string key, [FromQuery] Guid userId)
          {
             await _userLoggedEvent.Logout(key,userId);  
          }

    }
}