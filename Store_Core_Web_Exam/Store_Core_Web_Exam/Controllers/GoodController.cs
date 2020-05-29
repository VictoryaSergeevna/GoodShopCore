using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store_Core_Web_Exam.EF;
using Store_Core_Web_Exam.Models;
using Store_Core_Web_Exam.Unit;

namespace Store_Core_Web_Exam.Controllers
{
    public class GoodController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly IUnitOfWork unit;
        public GoodController(IUnitOfWork u, IWebHostEnvironment environment)
        {
            unit = u;
            this.environment = environment;

        }

        public async Task<IActionResult> Index()
        {
           
            return View("IndexAdmin", await unit.Goods.GetAllAsync());
        }






        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await unit.Categories.GetAllAsync(), "Id", "CategoryName");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GoodViewModel goodWM)
        {
            if (goodWM.UploadedFile != null)
            {
                string path = "/Files" + goodWM.UploadedFile.FileName;
                using (FileStream file = new FileStream(environment.WebRootPath + path, FileMode.Create))
                {
                    await goodWM.UploadedFile.CopyToAsync(file);
                }
                Good good = new Good();
                good = goodWM.good;            
                good.FileName = goodWM.UploadedFile.FileName;
                good.Path = path;
                await unit.Goods.CreateAsync(good);
                

            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            
            var g = await unit.Goods.GetByIdAsync(id);
            if (g != null)
            {
                GoodViewModel vm = new GoodViewModel { good = g, CategoryId = g.CategoryId };
                ViewData["CategoryId"] = new SelectList(await unit.Categories.GetAllAsync(), "Id", "CategoryName");
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GoodViewModel goodWM)
        {
          
            if (goodWM.UploadedFile != null)
            {
                string path = "/Files" + goodWM.UploadedFile.FileName;
                using (FileStream file = new FileStream(environment.WebRootPath + path, FileMode.Create))
                {
                    await goodWM.UploadedFile.CopyToAsync(file);
                }
               goodWM.good.FileName=goodWM.UploadedFile.FileName;
               goodWM.good.Path = path;
            }
            if (!(await unit.Goods.UpdateAsync(goodWM.good)))
                return View();

            return RedirectToAction("Index", await unit.Goods.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           
            Good good = await unit.Goods.GetByIdAsync(id);

            if (good != null)
            {
                return View(good);
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await unit.Goods.DeleteAsync(id);
            var goods = await unit.Goods.GetAllAsync();
            return RedirectToAction("Index", goods);
        }



      



    }
}