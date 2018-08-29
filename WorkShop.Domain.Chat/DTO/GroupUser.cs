using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShop.Domain.Chat.DTO
{
    public class GroupUser
    {
        public Guid Id { get; set; }
        public Guid GroupId { get;  set; }
        public Guid UserId { get;  set; }
    }
}
