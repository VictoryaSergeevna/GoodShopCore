using Store_Core_Web_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.EF
{
    public class ShopDbInitializer
    {
        public static async Task Initialize(ShopContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                      new Category
                      {
                          Id = 1,
                          CategoryName = "мобильные телефоны"
                      },
                       new Category
                       {
                           Id = 2,
                           CategoryName = "телевизоры"
                       },
                 new Category
                 {
                     Id = 3,
                     CategoryName = "компьтеры"
                 }
                );
                context.SaveChanges();
            }
            if (!context.Goods.Any())
            {
                context.Goods.AddRange(
                      new Good
                      {
                          Id = 1,
                          Title = "iPhone 11 Pro Max",
                          Company = "Apple",
                          Price = 40000,
                          FileName = "1.jpg",
                          Path = "/Images/1.jpg",
                          CategoryId = 1
                      },
                       new Good
                       {
                           Id = 2,
                           Title = "Samsung Galaxy S20 Ultra",
                           Company = "Samsung",
                           Price = 38000,
                           FileName = "2.jpg",
                           Path = "/Images/2.jpg",
                           CategoryId = 1
                       },
                         new Good
                         {
                             Id = 3,
                             Title = "Huawei P40 Pro 8",
                             Company = "Huawei",
                             Price = 29000,
                             FileName = "3.jpg",
                             Path = "/Images/3.jpg",
                             CategoryId = 1
                         },
                          new Good
                          {
                              Id = 4,
                              Title = "Xiaomi Mi Note 10 Pro 8",
                              Company = "Xiaomi",
                              Price = 15000,
                              FileName = "4.jpg",
                              Path = "/Images/4.jpg",
                              CategoryId = 1
                          },

                           new Good
                           {
                               Id = 5,
                               Title = "Samsung QE98Q900RBUXUA",
                               Company = "Samsung",
                               Price = 2000000,
                               FileName = "5.jpg",
                               Path = "/Images/5.jpg",
                               CategoryId = 2
                           },
                            new Good
                            {
                                Id = 6,
                                Title = "Sony KD75XG8096BR2 Black",
                                Company = "Sony",
                                Price = 60000,
                                FileName = "6.jpg",
                                Path = "/Images/6.jpg",
                                CategoryId = 2
                            },
                             new Good
                             {
                                 Id = 7,
                                 Title = "Philips 65OLED854/12",
                                 Company = "Philips",
                                 Price = 70000,
                                 FileName = "7.jpg",
                                 Path = "/Images/7.jpg",
                                 CategoryId = 2
                             },
                                new Good
                                {
                                    Id = 8,
                                    Title = "LG OLED65W9PLA",
                                    Company = "LG",
                                    Price = 230000,
                                    FileName = "8.jpg",
                                    Path = "/Images/8.jpg",
                                    CategoryId = 2
                                },

                                 new Good
                                 {
                                     Id = 9,
                                     Title = "Apple MacBook Pro 16",
                                     Company = "Apple",
                                     Price = 97000,
                                     FileName = "9.jpg",
                                     Path = "/Images/9.jpg",
                                     CategoryId = 3
                                 },
                                 new Good
                                 {
                                     Id = 10,
                                     Title = "Dell Latitude 5501",
                                     Company = "Dell",
                                     Price = 87000,
                                     FileName = "10.jpg",
                                     Path = "/Images/10.jpg",
                                     CategoryId = 3
                                 }
                                  );
               await context.SaveChangesAsync();
            }
        }
    }
}
