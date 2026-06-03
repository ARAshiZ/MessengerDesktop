using MessengerDesktop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public class ChatUserRepository : IRepository<ChatUserModel>
    {
        public void Add(ChatUserModel ChatUser)
        {
            using (var context = new AppDbContext())
            {
                if (ChatUser.User != null)
                {
                    context.Users.Attach(ChatUser.User);  
                }
                context.ChatUsers.Add(ChatUser);
                context.SaveChanges();
            }
        }
        public void Delete(ChatUserModel ChatUser)
        {
            using (var context = new AppDbContext())
            {
                context.ChatUsers.Remove(ChatUser);
                context.SaveChanges();
            }
        }
        public void Update(ChatUserModel ChatUser)
        {
            using (var context = new AppDbContext())
            {
                context.ChatUsers.Update(ChatUser);
                context.SaveChanges();
            }
        }

        public IEnumerable<ChatUserModel> FindAll()
        {
            using (var context = new AppDbContext())
            {
                return context.ChatUsers
                    .Include(u => u.User)
                    .Include(m => m.Messages)
                    .ToList();
            }
        }

        public ChatUserModel FindByID(int ID)
        {
            using (var context = new AppDbContext())
            {
                return context.ChatUsers
                    .Where(entity => entity.Id == ID)
                    .Include(u => u.User)
                    .Include(m => m.Messages)
                    .FirstOrDefault();
            }
        }
    }
}
