using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerDesktop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MessengerDesktop.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<ChatUserModel> ChatUsers => Set<ChatUserModel>();
        public DbSet<MessageModel> Messages => Set<MessageModel>();
        public AppDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MessengerDatabase.db");
        }
    }
}
