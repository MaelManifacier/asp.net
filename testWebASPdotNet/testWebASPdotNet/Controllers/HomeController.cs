using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testWebASPdotNet.Models;

namespace testWebASPdotNet.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public string Ajouter(int valeur1, int valeur2)
        {
            int res = valeur1 + valeur2;
            return res.ToString();
        }
        
        public ActionResult ListeLapins()
        {
            Vallee v = new Vallee();
            ViewData["Lapins"] = v.GetListeLapins();

            return View();
        }

        public ActionResult ChercherLapin(string id)
        {
            ViewData["Nom"] = id;
            Vallee v = new Vallee();
            Lapin lapin = v.GetListeLapins().FirstOrDefault(l => l.Nom == id);
            if(lapin != null)
            {
                ViewData["Nom"] = lapin.Nom;
                return View("Trouve");
            } else
            {
                return View("PasTrouve");
            }
        }
  

        
        //truc/Home/Index/1
        /*public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View("Error");
            }
            ViewData["chose"] = id;
            return View();
            //return "hey"+id;
        }*/

        //truc/Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}