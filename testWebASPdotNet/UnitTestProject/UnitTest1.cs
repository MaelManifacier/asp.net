using System;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using testWebASPdotNet;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime aujourdhui = DateTime.Now;
            RouteData routeData = DefinirUrl(string.Format("~/{0}/{1}/{2}", aujourdhui.Day, aujourdhui.Month, aujourdhui.Year));

            //tests
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Meteo", routeData.Values["controller"]);
            Assert.AreEqual("AfficherMeteo", routeData.Values["action"]);
            Assert.AreEqual(aujourdhui.Day.ToString(), routeData.Values["jour"]);
            Assert.AreEqual(aujourdhui.Month.ToString(), routeData.Values["mois"]);
            Assert.AreEqual(aujourdhui.Year.ToString(), routeData.Values["annee"]);
        }

        private static RouteData DefinirUrl(string url)
        {
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData routeData = routes.GetRouteData(mockContext.Object);
            return routeData;
        }

        [TestMethod]
        public void Routes_UrlBidon_RetourneNull()
        {
            RouteData routeData = DefinirUrl("/Url/bidon/pas/bonne");
            Assert.IsNull(routeData);
        }
    }
}
