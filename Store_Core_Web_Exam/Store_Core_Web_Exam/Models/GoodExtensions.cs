using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Store_Core_Web_Exam.Repository;
using Store_Core_Web_Exam.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Models
{
    public static class GoodExtensions
    {
        public static void AddGood(this IServiceCollection services)
        {         
            services.AddTransient<IRepository<Good>, GoodRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<UserRepository>();
        }

        public static void UseGood(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GoodMiddleware>();
        }
    }
}
