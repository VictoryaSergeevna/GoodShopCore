using Microsoft.EntityFrameworkCore;
using Store_Core_Web_Exam.EF;
using Store_Core_Web_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Repository
{
    public class GoodRepository : IRepository<Good>
    {
        ShopContext db;
        public GoodRepository(ShopContext context)
        {
            this.db = context;
        }
        public async Task CreateAsync(Good item)
        {
            db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Good item = db.Goods.FirstOrDefault(g => g.Id == id);

            if (item != null)
            {
                db.Entry(item).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Good>> GetAllAsync()
        {
            return await db.Goods.Include(g => g.Category).ToListAsync();
        }

        public async Task<Good> GetByIdAsync(int Id)
        {
            return await db.Goods.Include(g => g.Category).FirstOrDefaultAsync(i => i.Id == Id);
           
        }

        public async Task<List<Good>> SearchAsync(string name)
        {
            return await db.Goods.Include(g => g.Category).Where(g => g.Category.CategoryName.Contains(name)).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Good item)
        {
            Good good = await GetByIdAsync(item.Id);
            if (good != null)
            {
                db.Entry(good).State = EntityState.Detached;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
