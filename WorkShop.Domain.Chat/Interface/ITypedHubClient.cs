using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Domain.Chat.Interface
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
