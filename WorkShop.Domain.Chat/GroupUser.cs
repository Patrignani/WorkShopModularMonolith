using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Domain.Chat
{
    public class GroupUser : Entity<GroupUser>
    {
        public GroupUser(Guid groupId, Guid userId)
        {
            GroupId = groupId;
            UserId = userId;
        }

        protected GroupUser()
        {

        }

        public Guid GroupId { get; private set; }
        public Guid UserId { get; private set; }

        public override async Task<bool> ValidationAsync()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("Usuário Id não pode ser nulo");;

                RuleFor(x => x.GroupId)
                .NotNull().WithMessage("Grupo Id não pode ser nulo");

              ValidationResult = await ValidateAsync(this);

             return ValidationResult.IsValid;
        }
    }
}
