using System;

namespace WorkShop.Domain.Client.DTO
{
    public class User
    {
        public Guid Id{ get; set; }
        public string Identification { get; set; }
        public string Password { get; set; }
    }
}