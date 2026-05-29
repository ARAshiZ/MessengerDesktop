using MessengerDesktop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public class MessageRepository : IRepository<MessageModel>
    {
        public void Add(MessageModel Message)
        {
            using (var context = new AppDbContext())
            {
                context.ChatUsers.Attach(Message.ChatUser);
                context.Messages.Add(Message);
                context.SaveChanges();
            }
        }
        public void Delete(MessageModel Message)
        {
            using (var context = new AppDbContext())
            {
                context.ChatUsers.Attach(Message.ChatUser);
                context.Messages.Remove(Message);
                context.SaveChanges();
            }
        }
        public void Update(MessageModel Message)
        {
            using (var context = new AppDbContext())
            {
                context.ChatUsers.Attach(Message.ChatUser);
                context.Messages.Update(Message);
                context.SaveChanges();
            }
        }

        public IEnumerable<MessageModel> FindAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Messages
                    .Include(cu => cu.ChatUser)
                    .ToList();
            }
        }

        public MessageModel FindByID(int ID)
        {
            using (var context = new AppDbContext())
            {
                return context.Messages
                    .Include(cu => cu.ChatUser)
                    .FirstOrDefault();
            }
        }
    }
}
