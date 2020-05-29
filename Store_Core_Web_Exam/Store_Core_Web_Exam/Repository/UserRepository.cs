using Microsoft.EntityFrameworkCore;
using Store_Core_Web_Exam.EF;
using Store_Core_Web_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Repository
{
    public class UserRepository
    {
        ShopContext db;

        public UserRepository(ShopContext contex)
        {
            this.db = contex;
        }


        public async Task<List<User>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task AddAsync(User item)
        {
            db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task<User> FindUserByLoginAsync(string email, string password)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
