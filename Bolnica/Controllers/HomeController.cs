using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using System.Net;

namespace Bolnica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your service page.";

            return View();
        }

        public ActionResult Schedule()
        {
            ViewBag.Message = "Your schedule.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Doctors() {
            return View();
        }


        public ActionResult CallBack()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CallBackResult(FormCollection submit)
        {
            try
            {
                string msg = submit["text"] + "; Mail: " + submit["email"];
                SendEmail(msg, "matvei.nazaruk@gmail.com", "callback", submit["fio"]);

                ViewBag.Result = "success";
            }
            catch
            {
                ViewBag.Result = "failed";

            }
            return View(); 
        }


        public ActionResult DoctorRequest() {
            return View();
        }

        [HttpPost]
        public ActionResult DoctorRequestResult(FormCollection submit) {
            try
            {
                String msg = submit["text"] + "; Номер телефона: " + submit["phone"] + "; Адрес: " + submit["address"];
                SendEmail(msg, "matvei.nazaruk@gmail.com", "doctor request", submit["fio"]);

                ViewBag.Result = "success";
            }
            catch
            {
                ViewBag.Result = "failed";

            }
            return View();
        }

        public ActionResult TicketRequest() {
            return View();
        }

        [HttpPost]
        public ActionResult TicketRequestResult(FormCollection submit)
        {
            try
            {
                String msg = submit["fio"] + "; Номер телефона: " + submit["phone"] +
                      "; На дату: " + submit["date"] + "; время: " + submit["time"] + "; к: " + submit["doctor"]; 
                SendEmail(msg, "matvei.nazaruk@gmail.com", "ticket request", submit["fio"]);

                ViewBag.Result = "success";
            }
            catch
            {
                ViewBag.Result = "failed";

            } 
            return View();
        }


        public void SendEmail(string msgBody, string sendFrom, string subject, string toName)
        {
            var fromAddress = new MailAddress(sendFrom, toName);
            var toAddress = new MailAddress(sendFrom, "Sviclochskaya central'naya gorodskaya bolnica");
            const string fromPassword = "6092726moiNOMER*";
            string body = msgBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
