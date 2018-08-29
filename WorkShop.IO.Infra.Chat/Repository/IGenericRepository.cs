using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Core.Interfaces;
using WorkShop.Domain.Core.Models;
using WorkShop.IO.Infra.Chat.Context;

namespace WorkShop.IO.Infra.Chat.Repository
{
    //public class IGenericRepository<T> : IRepository<T> where T : Entity<T>
    //{
    //    private ChatContext _chatContext;
      
    //    public IGenericRepository(ChatContext chatContext)
    //    {
    //        _chatContext = chatContext;

    //    }

    //    public void Add(T obj)
    //    {
    //        _chatContext.Add(obj);
    //    }

    //    public void Dispose()
    //    {
    //        _chatContext.Dispose();
    //    }

    //    public async Task SaveChangesAsync()
    //    {
    //        await _chatContext.SaveChangesAsync();
    //    }

    //}
}
