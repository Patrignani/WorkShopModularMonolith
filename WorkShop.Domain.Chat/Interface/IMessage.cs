﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkShop.Domain.Core.Interfaces;

namespace WorkShop.Domain.Chat.Interface
{
    public interface  IMessage : IRepository<Message>
    {
    }
}
