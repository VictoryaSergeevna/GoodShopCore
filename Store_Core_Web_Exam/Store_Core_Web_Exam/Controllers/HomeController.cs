using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store_Core_Web_Exam.EF;
using Store_Core_Web_Exam.Models;
using Store_Core_Web_Exam.Repository;
using Store_Core_Web_Exam.Unit;

namespace Store_Core_Web_Exam.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IWebHostEnvironment environment;
        private readonly IUnitOfWork unit;
       
        public HomeController(IUnitOfWork u, IWebHostEnvironment environment)
        {
            this.unit = u;
            this.environment = environment;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewBag.user = User.Identity.Name;
            return View(await unit.Goods.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await unit.Goods.GetByIdAsync(id);
            if (item != null)
            {
                return View(item);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.GoodId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            unit.Orders.CreateAsync(order);           
            return "Спасибо, " + order.User + ", за покупку!";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string search_name)
        {
            var all_goods = await unit.Goods.SearchAsync(search_name);
            if (all_goods.Count() <= 0)
            {
                return NotFound();
            }
            return View("SearchGood",all_goods);
        }

       

        //    public IActionResult Privacy()
        //    {
        //        return View();
        //    }

        //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //    public IActionResult Error()
        //    {
        //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
    }
}
