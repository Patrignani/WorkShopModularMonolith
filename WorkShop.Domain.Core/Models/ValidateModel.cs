using System.Collections.Generic;

namespace WorkShop.Domain.Core.Models
{
    public class ValidateModel
    {

        public ValidateModel()
        {
             Message = new List<string>();

        }
         public bool Sucess{get;set;}
         public List<string> Message{get;set;}
    }
}