using System;

namespace WorkShop.Domain.Client.DTO
{
    public class UserLogged
    {
        public Guid UserId { get;  set; }
        public DateTime DataLogged { get;  set; }
        public DateTime DataCheck { get;  set; }
        public string Hash { get;  set; }
        public string Ip { get;  set; }
    }
}