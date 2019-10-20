Modele :
- ORM (Object Relational Mapping) : Entity Framework

MVC : permet une séparation claire des intentions

"convention plutôt que configuration"

UN PATRON DE CONCEPTION EST LA MEILLEURE SOLUTION CONNUE A UN PROBLEME DE CONCEPTION RECURRENT

-----------------------------------------------------------------

Lorsque l'on créée un projet : (Application web ASP.NET (.NET Framework))
# https://openclassrooms.com/fr/courses/1730206-apprenez-asp-net-mvc/1828211-les-tests-automatiques

Créer un nouveau controller -> là où les requêtes vont "arriver" 
-> ceci est défini dans App_Start/RouteConfig.cs
= defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
par défaut, le site s'ouvre avec le controller nommé HomeController et la méthode appelée est la méthode Index (qui va
donc généralement retourner une View).

L'url est transformée en : url: "{controller}/{action}/{id}" -> Home/Index  (/rien comme il n'y a pas ici d'id).


# METHODE DE CONTROLLER APPELEE :
Si on donne un id à la méthode index :
public void Index(int id) { }

-> pour y accéder il faudra faire : 
http://localhost:63942/Home/Index?id=1
ou: /Home/Index/1

On peut aussi donner un string ou autre
-> Par contre, il est obligatoire que le nom du paramètre soit "id"

Si l'on veut que l'id ne soit pas obligatoire :
public string Index(int? id) -> on ajoute un ? => ce qui veut dire que l'entier donné est nullable


Dans le controller on "return View" :
# VIEW
Si controller nommé HomeController, dans view on ajoute un dossier Home avec Index.cshtml et d'autres si l'on veut
-> la méthode View() va chercher la vue qui est dans un répertoire du même nom que le controleur et avec un nom de vue qui correspond au nom de la méthode (Index par défaut)
-> si dans le controleur la méthode est :
public ActionResult LaDeuxiemeVue() { return View(); }
la vue va être appelée LaDeuxiemeVue.cshtml

Dans View/ le répertoire Shared permet de créer par exemple une erreur qui pourra être appelée depuis n'importe où
return View("Error");
-> si ASP ne trouve pas la vue dans le répertoire du même nom que le controleur, il ira chercher dans Shared.


# Controleur

Récupérer valeur :
        ViewData["Nom"] = id;
Pour affichage dans html :
		<p>@ViewData["Nom"]<p>
OU      @ViewBag.Nom  (après ViewBag.Nom = id;)

# plusieurs valeurs d'entrée
dans RouteConfig.cs :
defaults: new { controller = "Home", action = "Index", valeur1 = 0, valeur2 = 0 }
-> public ActionResult Index(int valeur1, int valeur2) { }
Route : http://localhost:49874/Home/Index/1/2

On peut changer le fait de devoir séparer les données par "/"
->tjs dans RouteConfir : url: "Calculatrice-{action}/{valeur1}-{valeur2}"
ou encore : url: "{action}/{valeur1}-{valeur2}"

# plusieurs routes

L'ordre des routes est important -> si on met default en premier, l'appli ne va pas tester les autres

routes.MapRoute(
    name: "Ajouter",
    url: "Ajouter/{valeur1}/{valeur2}",
    defaults: new { controller = "Calculateur", action = "Ajouter" });

-> /Ajouter/4/7

# contraintes sur la route :

    defaults: new { controller = "Meteo", action = "Afficher" },
    constraints: new { jour = @"\d+", mois = @"\d+", annee = @"\d{4}" }); -> doivent n'être que des entiers
(4 jours pour l'année, voir expressions régulières)

# nombre indéterminé de paramètre :
url: "{controller}/{action}/{*id}"*
(sans l'étoile à la fin) -> * id permet d'intercepter tout ce qui reste après controller/action
Si on donne : /Home/Index/123/456, l'id vaudra 123/456


# faire un lien :
<a href="/Home/Afficher/123">Mon lien</a>
ou
public string Index(string id)
{
    return HtmlHelper.GenerateLink(Request.RequestContext, RouteTable.Routes, "Mon lien", null, "Afficher", "Home", new RouteValueDictionary { { "id", id } }, null);
}
-> permet d'éviter les url en dur qui risquent de ne rien renvoyer si nous changeons les règles de routing











-----------------------------------------------------------------

Si l'appli console s'ouvre et se ferme tt de suite, "exécuter sans débogage"

-----------------------------------------------------------------

Instructions .NET

DateTime.Now
	-> appelle System.DateTime.Now (namespace System)
on fait donc:
# using System;

utilisateur courant Windows:
# Environment.UserName


DateTime.Today.AddDays(1);
new DateTime(2009, 8, 8);
DateTime.Today; -> 8 août 2009 00:00:00
DateTime.UtcNow; -> 8 août 2009 20:55:37
Affichage :
ToLongDateString(); -> samedi 8 août 2009
ToLongTimeString(); -> 22:55:37
...

#diff DateTime et TimeSpan
Datetime = instant t
TimeSpan = intervalle de temps

EXEMPLE :
TimeSpan exeDuration = DateTime.Now.Subtract(exeStart);
string exeTime = string.Format(
	"Temps d'exécution : {0}h, {1}m, {2}s et {3}ms.",
	exeDuration.Hours,
	exeDuration.Minutes,
	exeDuration.Seconds,
	exeDuration.Milliseconds);


#Timer(s)
Timer serveur (à ajouter ds boîte à outils) -> https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=MSDN&view=netframework-4.8
Time Windows
Timer thread -> https://docs.microsoft.com/en-us/dotnet/api/system.threading.timer?redirectedfrom=MSDN&view=netframework-4.8


Référencer ASSEMBLY :
assembly : fichiers.dll, fragments de code des appels comme DateTime.Now
GAC : Global Assembly Cache -> là où sont stockés les assembly
Dans chaque projet : fichier Références puis Microsoft.CSharp, System.Core, ...

On peut ajouter des références:
- framework : trouver des assemblys du framework
- extensions : trouver des assemblys qui ne font pas directement partie du framework .NET
- solution : références des assemblys qui se trouvent dans notre solution
- COM : "ancêtre de l'assembly" -> VS va générer un wrapper pour utiliser la dll COM
- parcourir : depuis le disque dur (genre pour assembly fournie par un collègue ou quoi)

mscorelib.dll : présente de base et obligatoirement



-------------------------- TESTS ---------------------------------------

-> ajouter un projet de test à la solution existante (clic droit sur la solution)
	+ ajouter la référence au projet web (au projet de base)
ou création d'un projet avec tests unitaires (case à cocher)


double resultat = MathHelper.Factorielle(0);
Assert.AreEqual(1, resultat);

# exécuter les tests :
dans la navbar : Tests -> exécuter -> tous les tests (ou pas)


# framework de 'simulacre' (genre Mockup) pour ASP.NET :
Moq (/moque-you/) ou Fakes -> payant
Pour Moq :
Clic droit sur projet de test
Gérer les packages NuGet
chercher Moq en ligne
installer

Exemple :
[TestMethod]
public void ObtenirLaMeteoDuJour_AvecUnBouchon_RetourneSoleil()
{
    Meteo fausseMeteo = new Meteo
    {
        Temperature = 25,
        Temps = Temps.Soleil
    };
    Mock<IDal> mock = new Mock<IDal>();
    mock.Setup(dal => dal.ObtenirLaMeteoDuJour()).Returns(fausseMeteo);

    IDal fausseDal = mock.Object;
    Meteo meteoDuJour = fausseDal.ObtenirLaMeteoDuJour();
    Assert.AreEqual(25, meteoDuJour.Temperature);
    Assert.AreEqual(Temps.Soleil, meteoDuJour.Temps);
}



