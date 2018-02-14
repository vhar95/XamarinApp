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

        private const string url = "http://localhost:8000/api/usuarios";
        private HttpClient _Client = new HttpClient();
        DateTime f = DateTime.Today.Date;
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
                FechaN = string.Empty;
                Nivel = string.Empty;

            }
          );

            Guardar = new Command(async () => {
                User modelo = new User()
                {

                    Nombre = Nombre,
                    Apellidos = Apellidos,
                    Nick = Nick,
                    Sexo = "hombre",
                    Correo = Correo,
                    Telefono = Telefono,
                    Skype = Skype,
                    FechaN = f.ToString("yyyy-MM-dd"),
                    Nivel = Nivel
            };
                string con = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(con, Encoding.UTF8, "application/json");
                var result = await _Client.PostAsync(url, content);
                System.Diagnostics.Debug.WriteLine(con);
                var code = result.ReasonPhrase;
                var c = result.RequestMessage;
                var co = result.Headers;
                System.Diagnostics.Debug.WriteLine(co);
                System.Diagnostics.Debug.WriteLine(c);
                System.Diagnostics.Debug.WriteLine(code);

            }
             );
        }
    }
}
