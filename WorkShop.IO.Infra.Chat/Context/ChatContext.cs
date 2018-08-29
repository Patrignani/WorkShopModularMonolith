using Microsoft.EntityFrameworkCore;
using WorkShop.Domain.Chat;

namespace WorkShop.IO.Infra.Chat.Context
{
    public class ChatContext: DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
           : base(options)
        {


        }

        public DbSet<Group> Group { get; set; }
        public DbSet<GroupUser> GroupUser { get; set; }
         public DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {

            model.ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(model);

             model.Entity<Group>()
            .HasIndex(x => x.Identification)
            .IsUnique();
        }
    }
}