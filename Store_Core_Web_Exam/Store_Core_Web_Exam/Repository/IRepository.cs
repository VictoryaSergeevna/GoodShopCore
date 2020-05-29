using Store_Core_Web_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Repository
{
    public interface IRepository<T> where T : class
    {
      
        Task<T> GetByIdAsync(int Id);
        Task<List<T>> GetAllAsync();       
        Task CreateAsync(T item);
        Task<bool> UpdateAsync(Good item);
        Task DeleteAsync(int id);
        Task<List<T>> SearchAsync(string name);
    }
}
