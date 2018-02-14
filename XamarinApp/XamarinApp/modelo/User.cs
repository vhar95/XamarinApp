using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace XamarinApp.modelo
{
    public class User : INotifyPropertyChanged
    {
 
        private string nombre;
        private string apellidos;
        private string nick;
        private string sexo;
        private string correo;
        private string telefono;
        private string skype;
        private string fechaN;
        private string nivel;
        private string pass;
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
        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {

                if (apellidos != value)
                {
                    apellidos = value;
                    OnPropertyChanged("apellidos");
                }

            }
        }
        public string Nick
        {
            get
            {
                return nick;
            }

            set
            {

                if (nick != value)
                {
                    nick = value;
                    OnPropertyChanged("nick");
                }

            }
        }
        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {

                if (sexo != value)
                {
                    sexo = value;
                    OnPropertyChanged("sexo");
                }

            }
        }
        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {

                if (correo != value)
                {
                    correo = value;
                    OnPropertyChanged("correo");
                }

            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {

                if (telefono != value)
                {
                    telefono = value;
                    OnPropertyChanged("telefono");
                }

            }
        }
        public string Skype
        {
            get
            {
                return skype;
            }

            set
            {

                if (skype != value)
                {
                    skype = value;
                    OnPropertyChanged("skype");
                }

            }
        }
        public string FechaN
        {
            get
            {
                return fechaN;
            }

            set
            {

                if (fechaN != value)
                {
                    fechaN = value;
                    OnPropertyChanged("fechaN");
                }

            }
        }
        public string Nivel
        {
            get
            {
                return nivel;
            }

            set
            {

                if (nivel != value)
                {

                    nivel = value;
                    OnPropertyChanged("Niveles");
                }

            }
        }
        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {

                if (pass != value)
                {

                    pass = value;
                    OnPropertyChanged("pass");
                }

            }
        }


    }

}
