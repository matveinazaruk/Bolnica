using Bolnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bolnica.Controllers
{
    public class DoctorController : Controller
    {
        DoctorInfoEntities2 db = new DoctorInfoEntities2();
        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            var doctors = (from doctor in db.Doctors select doctor).ToList();
            return View(doctors);
        }

    }
}
