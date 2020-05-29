using Microsoft.EntityFrameworkCore;
using Store_Core_Web_Exam.EF;
using Store_Core_Web_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        ShopContext db;
        public OrderRepository(ShopContext context)
        {
            this.db = context;
        }
        public async Task CreateAsync(Order item)
        {
            db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Order item = db.Orders.FirstOrDefault(o => o.OrderId== id);

            if (item != null)
            {
                db.Entry(item).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int Id)
        {
            return await db.Orders.FirstOrDefaultAsync(o => o.OrderId == Id);
        }

        public async Task<List<Order>> SearchAsync(string name)
        {
            return await db.Orders.Where(g => g.User.Contains(name)).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Good item)
        {
            Order order = await GetByIdAsync(item.Id);
            if (order != null)
            {
                db.Entry(order).State = EntityState.Detached;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
