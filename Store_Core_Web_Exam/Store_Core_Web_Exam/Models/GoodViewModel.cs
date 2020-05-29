using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Models
{
    public class GoodViewModel
    {
        public Good good { set; get; }
        public IFormFile UploadedFile { get; set; }
        public int CategoryId { get; set; }
    }
}
