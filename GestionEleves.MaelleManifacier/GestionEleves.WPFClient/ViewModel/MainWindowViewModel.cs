using GestionEleves.WPFClient.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.WPFClient.ViewModel
{
    // BaseViewModel -> interface pour faire du MVVM / du binding
    public class MainWindowViewModel : BaseViewModel
    {
        private ListeEleveViewModel _listeEleveViewModel;
        
        public ListeEleveViewModel ListeEleveViewModel
        {
            get { return _listeEleveViewModel; }
            set { _listeEleveViewModel = value; }
        }

        public MainWindowViewModel()
        {
            ListeEleveViewModel = new ListeEleveViewModel();
        }
    }
}
