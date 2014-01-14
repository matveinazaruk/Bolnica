using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bolnica.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/
        public ActionResult Consultation()
        {
            ViewBag.Message = "Consultation prices.";
            return View();
        }
        public ActionResult Fito()
        {
            ViewBag.Message = "Fitoterapy prices.";
            return View();
        }
        public ActionResult Immunization()
        {
            ViewBag.Message = "Immunization prices.";
            return View();
        }
        public ActionResult Massage()
        {
            ViewBag.Message = "Massage prices.";
            return View();
        }
        public ActionResult ProphView()
        {
            ViewBag.Message = "ProphView prices.";
            return View();
        }
        public ActionResult Research()
        {
            ViewBag.Message = "Research prices.";
            return View();
        }

    }
}
