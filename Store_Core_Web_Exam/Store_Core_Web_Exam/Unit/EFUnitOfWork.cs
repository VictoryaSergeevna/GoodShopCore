using Store_Core_Web_Exam.EF;
using Store_Core_Web_Exam.Models;
using Store_Core_Web_Exam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Unit
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public IRepository<Good> goods;
        public IRepository<Category> categories;
        public IRepository<Order> orders;

        ShopContext db;
        public EFUnitOfWork(ShopContext context)
        {
            this.db = context;
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orders == null)
                    orders = new OrderRepository(db);
                return orders;
            }
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (categories == null)
                    categories = new CategoryRepository(db);
                return categories;
            }
        }
        public IRepository<Good> Goods
        {
            get
            {
                if (goods == null)
                    goods = new GoodRepository(db);
                return goods;
            }
        }

        

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
