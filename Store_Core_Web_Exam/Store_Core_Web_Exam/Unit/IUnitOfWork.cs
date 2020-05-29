using Store_Core_Web_Exam.Models;
using Store_Core_Web_Exam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Unit
{
    public interface IUnitOfWork
    {
        IRepository <Good> Goods { get; }
        IRepository <Category> Categories { get; }
        IRepository<Order> Orders { get; }
        Task Save();

    }
}
