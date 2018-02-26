using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class Noticia : INotifyPropertyChanged
    {
        private string titulo;
        private string descripcion;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }


        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {

                if (titulo != value)
                {
                    titulo = value;
                    OnPropertyChanged("titulo");
                }

            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {

                if (descripcion != value)
                {
                    descripcion = value;
                    OnPropertyChanged("descripcion");
                }

            }
        }

        public int id { get; set; }
    }
}
