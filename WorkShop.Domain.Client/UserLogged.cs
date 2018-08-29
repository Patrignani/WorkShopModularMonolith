using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Client;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Client
{
    public class UserLogged : Entity<UserLogged>
    {
        
        public UserLogged(Guid userId, DateTime dataLogged, string ip)
        {
            var date = DateTime.UtcNow;
            UserId = userId;
            DataLogged = dataLogged;
            Hash = (date.Hour.ToString() 
            +date.Month.ToString() 
            +date.Second+date.Millisecond.ToString()
            +date.Minute.ToString() 
            +userId.ToString()).ForSha3();
            Ip = ip;
        }

        protected UserLogged()
        {

        }

        public void SetDataCheck()
        {
            DataCheck = DateTime.UtcNow;
        }

        public void SetHash(string hash)
        {
            Hash= hash;
        }
        public Guid UserId { get; private set; }
        public DateTime DataLogged { get; private set; }
        public DateTime DataCheck { get; private set; }
        public string Hash { get; private set; }
        public string Ip { get; private set; }

        public virtual ICollection<User> User { get;  private set; }
       

        public override Task<bool> ValidationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
