using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Store.BusinessLogic.Models;

namespace Store.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}