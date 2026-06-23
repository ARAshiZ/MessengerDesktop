using MessengerDesktop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task Add(UserModel User)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(User);
                context.SaveChanges();
            }
        }
        public async Task Delete(UserModel User)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Remove(User);
                context.SaveChanges();
            }
        }
        public async Task Update(UserModel User)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Update(User);
                context.SaveChanges();
            }
        }

        public async Task<IEnumerable<UserModel>> FindAll() 
        {
            using (var context = new AppDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<UserModel> FindByID(int ID)
        {
            using (var context = new AppDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Id == ID);
            }
        }

        public async Task<UserModel> FindByName(string Name)
        {
            using (var context = new AppDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Name == Name);
            }
        }

        public async Task<UserModel> VerifyPersonalKey(string Key)
        {
            using (var context = new AppDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.PersonalKey == Key);
            }
        }
    }
}
