using Bolnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bolnica.Controllers
{
    public class SubdivisionController : Controller
    {
        DoctorInfoEntities2 db = new DoctorInfoEntities2();
        //
        // GET: /Subdivision/

        public ActionResult Index()
        {
            List<Subdivision> subdivisions = (from subdivision in db.Subdivisions 
                                select subdivision ).ToList();
            List<Doctor> doctors = (from doctor in db.Doctors
                                    select doctor).ToList();

            List<SubdivisionFullModel> subs = new List<SubdivisionFullModel>(subdivisions.Count);

            for (int i = 0; i < subs.Capacity; i++) { 
                int manId = subdivisions.ElementAt(i).ManagerId;
                string manName = "";
                string manNumber = "";

                for (int j = 0; j < doctors.Count(); j++){
                    if (doctors.ElementAt(j).Id == manId){
                        manName = doctors.ElementAt(j).Name;
                        manNumber = doctors.ElementAt(j).PhoneNumber;
                        break;
                    }
                }
                subs.Add(new SubdivisionFullModel(
                    subdivisions.ElementAt(i).Name,
                    manName, manNumber));
            }


            return View(subs);
        }

    }
}
