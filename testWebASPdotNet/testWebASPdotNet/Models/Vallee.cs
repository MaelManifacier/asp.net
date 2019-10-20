using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testWebASPdotNet.Models
{
    public class Vallee
    {
        private List<Lapin> listeLapins = new List<Lapin>();

        public List<Lapin> GetListeLapins()
        {
            return new List<Lapin>
            {
                new Lapin("hey"),
                new Lapin("coucou"),
                new Lapin("hola")
            };
        }
    }
}