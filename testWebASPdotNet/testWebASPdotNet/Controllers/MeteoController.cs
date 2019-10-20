using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testWebASPdotNet.Controllers
{
    public class MeteoController : Controller
    {
        // GET: Meteo
        public string AfficherMeteo(int jour, int mois, int annee)
        {
            return "Nous sommes le "+jour+"/"+mois+"/"+annee;
        }
    }
}
