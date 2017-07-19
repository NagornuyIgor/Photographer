using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotographerPerformance.Web.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Default
        public ActionResult Photographers()
        {
            return View();
        }

        public ActionResult Photos()
        {
            return View();
        }
    }
}
