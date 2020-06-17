using GestionEleves.DAL.Entites;
using GestionEleves.WPFClient.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.WPFClient.ViewModel
{
    public class DetailEleveViewModel : BaseViewModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Note> notes { get; set; }
        public double Moyenne { get; set; }
    }
}
