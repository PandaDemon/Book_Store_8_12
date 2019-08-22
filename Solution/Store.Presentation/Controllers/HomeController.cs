using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services;
using Store.DataAccess.Entities;
using Store.Presentation.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Store.Presentation.Controllers
{
    public class HomeController : Controller
    {
        //private DataBaseContext _context;
        //private IAuthor _dirRep;
        private DataManager _dataManager;

        public HomeController(/*DataBaseContext context, IAuthor dirRep,*/ DataManager dataManager)
        {
            //_context = context;
            //dirRep = _dirRep;
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            //List<Author> _dirs = _dirRep.GetAllAutor().ToList();
            List<PrintingEdition> _dirs = _dataManager.PrintingEdition.GetAllPrintingEdition().ToList();
            return View(_dirs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
