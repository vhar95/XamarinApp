using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace XamarinApp.modelo
{
    public class UserView : User
    {
        public ICommand Guardar { get; private set; }
        public ICommand Nuevo { get; private set; }
        public ICommand Update { get; private set; }

        List<string> niveles = new List<string>
        {
            "A2","B1","B2","C1","C2"
        };
        public List<string> Niveles => niveles;

        List<string> sexos = new List<string>
        {
            "Hombre","Mujer"
        };
        public List<string> Sexos => sexos;

        //private const string url = "http://localhost:8000/api/usuarios";
        //private const string urlUpdate = "http://localhost:8000/api/usuarios/";
        private const string url = "https://apitwe.herokuapp.com/api/usuarios";
        private const string urlUpdate = "https://apitwe.herokuapp.com/api/usuarios/";

        private HttpClient _Client = new HttpClient();
        DateTime f = DateTime.Today.Date;
      
        public UserView()
        {
            Nuevo = new Command(() => {

         
                Nombre = string.Empty;
                Apellidos = string.Empty;
                Nick = string.Empty;
                Sexo = string.Empty;
                Correo = string.Empty;
                Telefono = string.Empty;
                Skype = string.Empty;
                FechaN = f;
                Nivel = string.Empty;
                Pass = string.Empty;

            }
          );

           Guardar = new Command(async () => {
                User modelo = new User()
                {

                    Nombre = Nombre,
                    Apellidos = Apellidos,
                    Nick = Nick,
                    Sexo = Sexo,
                    Correo = Correo,
                    Telefono = Telefono,
                    Skype = Skype,
                    FechaN = FechaN,
                    Nivel = Nivel,
                    Pass = Pass
            };

                
                string con = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(con, Encoding.UTF8, "application/json");
                var result = await _Client.PostAsync(url, content);
                System.Diagnostics.Debug.WriteLine(con);
                var code = result.IsSuccessStatusCode;

                
            }
          );

            Update = new Command(async () =>
            {
                User modelo = new User()
                {

                    Nombre = Nombre,
                    Apellidos = Apellidos,
                    Nick = Nick,
                    Sexo = Sexo,
                    Correo = Correo,
                    Telefono = Telefono,
                    Skype = Skype,
                    FechaN = FechaN,
                    Nivel = Nivel,
                    Pass = Pass
                };


                string con = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(con, Encoding.UTF8, "application/json");
                var result = await _Client.PutAsync(urlUpdate+App.UserId, content);
                System.Diagnostics.Debug.WriteLine(con);
                var code = result.IsSuccessStatusCode;
                if(code != false)
                {
                    App.UserId = 0;
                    App.UserCorreo = "";
                    App.UserNombre = "";
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
               

            }
           
                );

        
        }
    }
}
