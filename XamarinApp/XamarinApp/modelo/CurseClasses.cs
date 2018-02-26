using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class CurseClasses : INotifyPropertyChanged
    {
        
        private string nombre;
        private string duracion;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }


        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {

                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged("nombre");
                }

            }
        }

        public string Duracion
        {
            get
            {
                return duracion;
            }

            set
            {

                if (duracion != value)
                {
                    duracion = value;
                    OnPropertyChanged("duracion");
                }

            }
        }

        public int ID { get; set; }
    }
}
