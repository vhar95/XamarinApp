using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinApp.modelo
{
    public class CurseClassesView: CurseClasses
    {
        
        public ICommand Add { get; private set; }
        //private const string url = "http://localhost:8000/api/cursos";
        private const string url = "https://apitwe.herokuapp.com/api/cursos";
        private HttpClient _Client = new HttpClient();

        public CurseClassesView()
        {
            Add = new Command(async () => {

                CurseClasses modelo = new CurseClasses()
                {

                    Nombre = Nombre,
                    Duracion = Duracion

                };

                string con = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(con, Encoding.UTF8, "application/json");        
                var result = await _Client.PostAsync(url, content);
                var code = result.IsSuccessStatusCode;
                System.Diagnostics.Debug.WriteLine(code);



            }
          );

        }
    }
}
