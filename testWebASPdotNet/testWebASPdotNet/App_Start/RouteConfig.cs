using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace testWebASPdotNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Ajouter",
                url: "Ajouter/{valeur1}/{valeur2}",
                defaults: new { controller = "Home", action = "Ajouter" }
            );

            routes.MapRoute(
                name: "Meteo",
                url: "{jour}/{mois}/{annee}",
                defaults: new { controller = "Meteo", action = "AfficherMeteo" },
                constraints: new { jour = @"\d+", mois = @"\d+", annee = @"\d{4}" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
