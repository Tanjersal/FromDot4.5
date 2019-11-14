﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Configuring.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() 
            => View(new Dictionary<string, string> { ["message"] = "This is the index action" });
    }
}