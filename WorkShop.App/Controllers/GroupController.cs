using Microsoft.AspNetCore.Mvc;
using WorkShop.Domain.Chat.Event;
using WorkShop.Domain.Client.Event;

namespace WorkShop.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController: ControllerBase
    {
        private UserLoggedEvent _userLoggedEvent;
        private GroupUserEvent _groupUserEvent;
        private GroupEvent _groupEvent;

        public GroupController(UserLoggedEvent userLoggedEvent, GroupUserEvent groupUserEvent, GroupEvent groupEvent)
        {
            _userLoggedEvent= userLoggedEvent;
            _groupUserEvent=groupUserEvent;
            _groupEvent =groupEvent;
        }
    }
}