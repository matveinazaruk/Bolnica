using Bolnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace Bolnica.Controllers
{
    public class ArticleController : Controller
    {
        DoctorInfoEntities3 db1 = new DoctorInfoEntities3();
        DoctorInfoEntities2 db = new DoctorInfoEntities2();
        //
        // GET: /Article/

        public ActionResult Index()
        {
            var articles = (from article in db1.ShortArticles
                            select article).ToList();
            
            
            return View(articles);
        }

        public ActionResult Article(int id) {
            var articles = (from article in db.Articles
                            select article).ToList();

            foreach (Article a in articles) {
                if (a.Id == id) {
                    return View(a);
                }
            }
            RedirectToAction("Index", "Article");
            return View();
        }

        private void setArticleText(Article article) {
            string filename = article.Content;             
            string newText = "";
            StreamReader sr = new StreamReader(filename);
            newText = sr.ReadToEnd();
            article.Content = newText;
            sr.Close();
            return;
        }
    }
}
