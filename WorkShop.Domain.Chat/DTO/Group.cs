using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShop.Domain.Chat.DTO
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Identification { get;  set; }
        public int TypeGroup { get;  set; }
    }
}
