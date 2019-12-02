using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });
        }

        public ViewResult List()
        {
            return View("Result", new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            });
        }
    }
}