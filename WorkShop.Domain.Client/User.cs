using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WorkShop.Domain.Client;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Client
{
    public class User : Entity<User>
    {
        public User(string identification, string password)
        {
            Identification = identification;

            if(!String.IsNullOrEmpty(password))
            {
                Password = password.ForSha3();
            }
        }

        protected User()
        {

        }

        public string Identification { get; private set; }
        public string Password { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastInteraction { get; private set; }

        public override async Task<bool> ValidationAsync()
        {
            RuleFor (x => x.Identification)
            .NotEmpty ().WithMessage ("A identificação não pode ser vazio")
            .Length (3, 150).WithMessage ("identificação entre 3 a 150 caracteres");

            RuleFor (x => x.Password)
            .NotEmpty ().WithMessage ("A Senha não pode ser vazio")
            .Length (3, 150).WithMessage ("Senha entre 3 a 150 caracteres");

            ValidationResult = await ValidateAsync(this);
            
           return ValidationResult.IsValid;
        }
    }
}
