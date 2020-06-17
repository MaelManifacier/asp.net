using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.WPFClient.ViewModel.Common
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Initialisation - Constructeurs
        protected BaseViewModel() { }
        #endregion

        #region Code
        /// <summary>
        /// Se déclenche lorsqu'une propriété de cet objet a une nouvelle valeur
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Déclenche l'évènement sur  l'évènement PropertyChanged
        /// </summary>
        /// <param name="propertyName">La propriété qui a une nouvelle valeur</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
