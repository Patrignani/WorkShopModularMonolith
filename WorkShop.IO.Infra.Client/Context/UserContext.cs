using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkShop.Client;

namespace WorkShop.IO.Infra.Client.Context
{
   public class UserContext: DbContext
    {
          public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {


        }

        public DbSet<User> User { get; set; }
        public DbSet<UserLogged> UserLogged { get; set; }
       

        protected override void OnModelCreating(ModelBuilder model)
        {

            model.ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(model);

            model.Entity<User>()
            .HasIndex(x => x.Identification)
            .IsUnique();
        }

    }
}
