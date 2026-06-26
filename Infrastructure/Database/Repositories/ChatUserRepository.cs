using MessengerDesktop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public class ChatUserRepository : IChatUserRepository
    {
        public async Task Add(ChatUserModel ChatUser)
        {
            using (var context = new AppDbContext())
            {
                if (ChatUser.User != null)
                {
                    context.Users.Attach(ChatUser.User);  
                }
                context.ChatUsers.Add(ChatUser);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(ChatUserModel ChatUser)
        {
            using (var context = new AppDbContext())
            {
                context.ChatUsers.Remove(ChatUser);
                await context.SaveChangesAsync();
            }
        }
        public async Task Update(ChatUserModel ChatUser)
        {
            using (var context = new AppDbContext())
            {
                context.ChatUsers.Update(ChatUser);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ChatUserModel>> FindAllByContact(int contactUserId)
        {
            using (var context = new AppDbContext())
            {
                return await context.ChatUsers
                    .Include(u => u.User)
                    .Include(m => m.Messages)
                    .Where(entity => entity.ContactUserId == contactUserId)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<ChatUserModel>> FindAll()
        {
            using (var context = new AppDbContext())
            {
                return await context.ChatUsers
                    .Include(u => u.User)
                    .Include(m => m.Messages)
                    .ToListAsync();
            }
        }

        public async Task<ChatUserModel> FindByID(int ID)
        {
            using (var context = new AppDbContext())
            {
                return await context.ChatUsers
                    .Where(entity => entity.Id == ID)
                    .Include(u => u.User)
                    .Include(m => m.Messages)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
