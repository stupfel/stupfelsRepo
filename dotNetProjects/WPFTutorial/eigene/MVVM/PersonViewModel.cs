using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _Model;

        //  Konstruktor

        public PersonViewModel(Person model)
        {
            _Model = model;
            _Name = _Model.Name;
            _Alter = _Model.Alter;
        }

        // Schnittstellen-Ereignis

        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        // Eigenschaften

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) return;
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private int _Alter;
        public int Alter
        {
            get { return _Alter; }
            set
            {
                if (_Alter == value) return;
                _Alter = value;
                OnPropertyChanged("Alter");
            }
        }
    }
}
