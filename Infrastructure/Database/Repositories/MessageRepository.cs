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
        public async Task Add(MessageModel Message)
        {
            using (var context = new AppDbContext())
            {
                context.Messages.Add(Message);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(MessageModel Message)
        {
            using (var context = new AppDbContext())
            {
                context.Messages.Remove(Message);
                await context.SaveChangesAsync();
            }
        }
        public async Task Update(MessageModel Message)
        {
            using (var context = new AppDbContext())
            {
                context.Messages.Update(Message);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MessageModel>> FindAll()
        {
            using (var context = new AppDbContext())
            {
                return await context.Messages
                    .Include(cu => cu.ChatUser)
                    .ToListAsync();
            }
        }

        public async Task<MessageModel> FindByID(int ID)
        {
            using (var context = new AppDbContext())
            {
                return await context.Messages
                    .Include(cu => cu.ChatUser)
                    .FirstOrDefaultAsync(msg => msg.Id == ID);
            }
        }
    }
}
