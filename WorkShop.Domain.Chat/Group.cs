using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Domain.Chat
{
    public class Group : Entity<Group>
    {
        public Group(string identification, int typeGroup)
        {
            Identification = identification;
            TypeGroup = typeGroup;
            Messages = new List<Message>();
            GroupUsers = new List<GroupUser>();
        }

        protected Group()
        {

        }

        public string Identification { get; private set; }
        public int TypeGroup { get; private set; }
        public virtual ICollection<Message> Messages { get; private set; }
        public virtual ICollection<GroupUser> GroupUsers { get; private set; }

        public override async Task<bool> ValidationAsync()
        {
            RuleFor (x => x.Identification)
            .NotEmpty ().WithMessage ("A identificação não pode ser vazio")
            .Length (3, 150).WithMessage ("identificação entre 3 a 150 caracteres");

            RuleFor (x => x.TypeGroup)
            .GreaterThan(0);

            ValidationResult = await ValidateAsync(this);

             return ValidationResult.IsValid;
        }
    }
}
