using Microsoft.AspNetCore.Http;
using Store_Core_Web_Exam.Repository;
using Store_Core_Web_Exam.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Core_Web_Exam.Models
{
    public class GoodMiddleware
    {
        RequestDelegate next;

        public GoodMiddleware(RequestDelegate request)
        {
            next = request;
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork sender)
        {
            context.Response.Headers["Content-type"] = "text/html; charset=utf-8";

            string ind = context.Request.Query["index"];

            await context.Response.WriteAsync("Hello");
        }
    }
}
