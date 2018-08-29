using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using WorkShop.Domain.Chat.Interface;

namespace WorkShop.Domain.Chat.DTO
{
   public class NotifyHub: Hub<ITypedHubClient>
    {
    }
}
