using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testWebASPdotNet.Models
{
    public class Lapin
    {
        public string Nom { get; set; }

        public Lapin(string nom)
        {
            this.Nom = nom;
        }
    }
}