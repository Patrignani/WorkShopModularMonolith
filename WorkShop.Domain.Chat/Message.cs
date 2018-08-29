using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Domain.Chat
{
    public class Message : Entity<Message>
    {
        public Message(Guid groupId, Guid userId, string messageValue)
        {
            GroupId = groupId;
            UserId = userId;
            MessageValue = messageValue;
        }

        protected Message()
        {

        }

        public Guid GroupId { get; private set; }
        public Guid UserId { get; private set; }
        public string MessageValue { get; private set; }

        public override Task<bool> ValidationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
