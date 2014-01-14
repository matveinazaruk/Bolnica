using Bolnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bolnica.Controllers
{
    public class JobController : Controller
    {

        public List<Job> jobs = new List<Job>();
        DoctorInfoEntities2 db = new DoctorInfoEntities2();
        //
        // GET: /Job/

        public ActionResult Edit(int id)
        {
            Job exJob = (from job in db.Jobs where job.Id == id select job).First();

            exJob.Name = Translitter.FromEngToRus(exJob.Name);
            return View(exJob);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Job exJob = (from job in db.Jobs where job.Id == id select job).First();

            try
            {
                db.Jobs.Remove(exJob);
                db.SaveChanges();
                UpdateModel(exJob);

                exJob.Name = Translitter.FromRusToEng(exJob.Name);
                db.Jobs.Add(exJob);
                db.SaveChanges();
                return RedirectToAction("AdminView");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(e.Message, e);
            }

            return View(exJob);
        }

        public ActionResult Create()
        {
            Job job = new Job();
            return View(job);
        }

        [HttpPost]
        public ActionResult Create(Job job)
        {
            try {
                if (ModelState.IsValid) {
                    job.HowMuch = 1;
                    int maxid = 0;
                    jobs.Clear();
                    jobs = (from job1 in db.Jobs select job1).ToList();

                    for (int i = 0; i < jobs.Count; i++ )
                    {
                        if (jobs.ElementAt(i).Id > maxid)
                        {
                            maxid = jobs.ElementAt(i).Id;
                        }
                    }
                    job.Id = ++maxid;
                    job.Name = Translitter.FromRusToEng(job.Name);
                    db.Jobs.Add(job);
                    db.SaveChanges();
                    return RedirectToAction("AdminView");
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception e){
                ModelState.AddModelError(e.Message, e);
            }

            return View(job);
        }


        public ActionResult Delete(int id)
        {

            Job exJob = (from job in db.Jobs where job.Id == id select job).First();
            exJob.Name = Translitter.FromEngToRus(exJob.Name);

            return View(exJob);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection fc)
        {
            Job exJob = (from job in db.Jobs where job.Id == id select job).First();

            try
            {
                if (ModelState.IsValid)
                {
                    db.Jobs.Remove(exJob);
                    db.SaveChanges();
                    return RedirectToAction("AdminView");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(e.Message, e);
            }

            return View(exJob);
        }


        [Authorize(Roles = "Administrator")] 
        public ActionResult AdminView() {
            jobs.Clear();
            jobs = (from job in db.Jobs select job).ToList();

            foreach (Job job in jobs) {
                job.Name = Translitter.FromEngToRus(job.Name);
            }
            return View(jobs); 
        }

        public ActionResult Index()
        {

            jobs.Clear();
            jobs = (from job in db.Jobs select job).ToList();

            foreach (Job job in jobs)
            {
                job.Name = Translitter.FromEngToRus(job.Name);
            }
            return View(jobs); 
        }

    }
}
