using MVC_AjaxHelperMetotlari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AjaxHelperMetotlari.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> veriler = new List<string>() { "Teknoloji", "Sağlık", "Giyim", "Gıda" };

            Session["liste"] = veriler;

            return View();
        }
        public PartialViewResult VeriYukle()
        {
            List<string> veriler =(List<string>) Session["liste"];

            System.Threading.Thread.Sleep(3000);

            return PartialView("_PartialPageVeriler",veriler);
        }

        public MvcHtmlString VeriSil(int id)
        {
            List<string> veriler = (List<string>)Session["liste"];
            veriler.RemoveAt(id);

            Session["liste"] = veriler;

            System.Threading.Thread.Sleep(2000);

            return MvcHtmlString.Empty;
        }

        public ActionResult Index2()
        {
            List<Kisi> kisiler = new List<Kisi>();

            if (Session["kisiler"] != null)
            {
                kisiler = (List<Kisi>)Session["kisiler"];
            }

            ViewBag.kisiler = kisiler;
            return View(new Kisi());
        }

        [HttpPost]
        public PartialViewResult Index2(Kisi kisi)
        {
            List<Kisi> kisiler = null;
    
            if (Session["kisiler"]!=null)
            {
                kisiler = (List<Kisi>)Session["kisiler"];
            }
            else
            {
                kisiler = new List<Kisi>();
            }

            kisi.Id = Guid.NewGuid();
            kisiler.Add(kisi);

            Session["kisiler"] = kisiler;
            System.Threading.Thread.Sleep(2000);
           
            return PartialView("_PartialPageKisiler",kisi);
        }

        public ActionResult Test() 
        {
            return View();
        }
    }
}