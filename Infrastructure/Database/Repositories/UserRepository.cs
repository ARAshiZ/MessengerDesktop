using MessengerDesktop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public class UserRepository : IRepository<UserModel>
    {
        public void Add(UserModel User)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(User);
                context.SaveChanges();
            }
        }
        public void Delete(UserModel User)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Remove(User);
                context.SaveChanges();
            }
        }
        public void Update(UserModel User)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Update(User);
                context.SaveChanges();
            }
        }

        public IEnumerable<UserModel> FindAll() 
        {
            using (var context = new AppDbContext())
            {
                return context.Users.ToList();
            }
        }

        public UserModel FindByID(int ID)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == ID);
            }
        }

        public UserModel FindByName(string Name)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Name == Name);
            }
        }
    }
}
