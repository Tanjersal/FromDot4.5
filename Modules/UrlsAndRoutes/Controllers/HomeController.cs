using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Index controller - prints request info
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        /// <summary>
        /// Custom variables segment
        /// </summary>
        /// <returns></returns>
        //public ViewResult CustomVariables()
        //{
        //    Result r = new Result
        //    {
        //        Controller = nameof(HomeController),
        //        Action = nameof(CustomVariables)
        //    };

        //    r.data["Id"] = RouteData.Values["Id"]; //routeData enables to access routing info

        //    return View("Result", r);
        //}

        /// <summary>
        /// Custom variables segment - model binding
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewResult CustomVariables(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariables)
            };

            r.data["Id"] = id ?? "<no value>";
            r.data["Url"] = Url.Action("CustomVariables", "Home", new { id = 12 });

            return View("Result", r);
        }


        /// <summary>
        /// Catchall segment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewResult List(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(List)
            };

            r.data["Id"] = id;
            r.data["catchall"] = RouteData.Values["catchall"];

            return View("Result", r);
        }
    }
}