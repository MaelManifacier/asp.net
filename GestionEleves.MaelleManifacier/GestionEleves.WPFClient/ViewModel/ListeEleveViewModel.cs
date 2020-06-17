using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.WPFClient.ViewModel
{
    public class ListeEleveViewModel
    {
        public List<DetailEleveViewModel> eleves { get; set; }
        //private ObservableCollection<DetailEleveViewModel> _eleves;
        public DetailEleveViewModel SelectedEleve { get; set; }
        private BusinessLayer.BusinessManager _bm;

        public ListeEleveViewModel()
        {
            _bm = BusinessLayer.BusinessManager.GetInstance();
            // Initialisation de la liste d'élèves
            eleves = new List<DetailEleveViewModel>();

            foreach(Eleve e in _bm.GetEleves())
            {
                DetailEleveViewModel detailEleve = new DetailEleveViewModel
                {
                    Nom = e.Nom,
                    Prenom = e.Prenom
                };

                List<Note> notes = _bm.GetNotesByEleve(e.EleveId);
                detailEleve.Moyenne = notes.Select(n => n.NoteEleve).Average();
                eleves.Add(detailEleve);

                /*eleves.Add(new DetailEleveViewModel
                {
                    Nom = e.Nom,
                    Prenom = e.Prenom
                });*/

                //eleves.Add(new DetailEleveViewModel { Nom = "Hey", Prenom = "YouThere" });
                //eleves.Add(new DetailEleveViewModel { Nom = "Rouana", Prenom = "Marie" });

                if (eleves != null && eleves.Count > 0)
                {
                    detailEleve = eleves.ElementAt(0);
                }
            }

        }
    }
}
