using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Chat.Constatnt;
using WorkShop.Domain.Chat.Interface;
using WorkShop.Domain.Core.Events;
using WorkShop.Domain.Core.Models;
using System.Linq;

namespace WorkShop.Domain.Chat.Event
{
    public class GroupEvent : Event<Domain.Chat.DTO.Group>
    {

        private IGroup _IGroup;

        public GroupEvent(IGroup iGroup)
        {
            _IGroup = iGroup;
        }

        public async Task<ResultModel<Domain.Chat.DTO.Group>> Insert(Domain.Chat.DTO.Group group)
        {
            var groupDomain = new Group(group.Identification, group.TypeGroup);
            await SetValidateObject<Group>(new string[1] { "Grupo Cadastrado" }, groupDomain, group);

            if (Object.Sucess)
            {
                _IGroup.Add(groupDomain);
                await _IGroup.SaveChangesAsync();
                group.Id = groupDomain.Id;
                SetObject(group);
               
            }

            return Object;
        }

        public async Task<Domain.Chat.DTO.Group> GetPublicGroup()
        {
            var group= (await _IGroup.FindAsync(x => x.Identification == DataInit.PublicGroup))
                .FirstOrDefault();

           return new DTO.Group()
            {
                Id = group.Id,
                Identification = group.Identification,
                TypeGroup = group.TypeGroup
            };
        }
    }
}
