using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoC_MVC.Controllers
{
    public class xLogger : ILogger
    {

        public bool FazAlgo()
        {
            return true;
        }
    }
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILogger Logger)
        {
            logger = Logger;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
