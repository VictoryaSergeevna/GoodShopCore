using Microsoft.EntityFrameworkCore;
using Store_Core_Web_Exam.EF;
using Store_Core_Web_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        ShopContext db;
        public CategoryRepository(ShopContext context)
        {
            this.db = context;
        }
        public async Task CreateAsync(Category item)
        {
            db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category item = db.Categories.FirstOrDefault(g => g.Id == id);

            if (item != null)
            {
                db.Entry(item).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int Id)
        {
            return await db.Categories.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<List<Category>> SearchAsync(string name)
        {
            return await db.Categories.Where(g => g.CategoryName.Contains(name)).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Good item)
        {
           Category category = await GetByIdAsync(item.Id);
            if (category != null)
            {
                db.Entry(category).State = EntityState.Detached;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
