using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Chat.Interface;
using WorkShop.Domain.Core.Events;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Domain.Chat.Event
{
    public class GroupUserEvent : Event<Domain.Chat.DTO.GroupUser>
    {

        private IGroupUser _IGroupUser;

        public GroupUserEvent(IGroupUser iGroupUser)
        {
            _IGroupUser = iGroupUser;
        }

        public async Task<ResultModel<Domain.Chat.DTO.GroupUser>> Insert(DTO.GroupUser groupUser)
        {
            var groupUserDomain = new GroupUser(groupUser.GroupId, groupUser.UserId);
            await SetValidateObject<GroupUser>(new string[1] { "Grupo Cadastrado" }, groupUserDomain, groupUser);

            if (Object.Sucess)
            {
                _IGroupUser.Add(groupUserDomain);
                await _IGroupUser.SaveChangesAsync();
                groupUser.Id = groupUserDomain.Id;
                SetObject(groupUser);

            }

            return Object;
        }

    }
}
