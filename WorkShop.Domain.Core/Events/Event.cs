using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Domain.Core.Events
{
    public abstract class Event<T>
    {
        protected ResultModel<T> Object { get; private set; }

        public Event()
        {
            NewResultModel();
        }

        public void NewResultModel()
        {
            Object = new ResultModel<T>();
        }

        public async Task SetValidateObject<TEntity>(string[] messageSucess, TEntity value, T model) 
            where TEntity : Entity<TEntity>
        {
            Object.Object = model;
            if (await value.ValidationAsync())
            {
                Object.Sucess = true;
                Object.Message.AddRange(messageSucess);
            }
            else
            {
                Object.Sucess = false;
                Object.Message.AddRange(value.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
           
        }

        public void SetObject(T model)
        {
            Object.Object = model;
        }

         
    }
}
