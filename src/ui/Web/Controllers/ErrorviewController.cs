using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace connect2door.Web.Controllers
{
    public class ErrorviewController : BaseController
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}