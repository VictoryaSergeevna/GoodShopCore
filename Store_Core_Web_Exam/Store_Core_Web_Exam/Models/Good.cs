using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Models
{
    public class Good
    {
        public int Id { get; set; }       
        public string Title { get; set; }       
        public string Company { get; set; }      
        public double Price { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
