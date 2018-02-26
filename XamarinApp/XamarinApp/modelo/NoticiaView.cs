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
    public class NoticiaView : Noticia
    {
        public ICommand Add { get; private set; }
        //private const string url = "http://localhost:8000/api/noticias";
        private const string url = "https://apitwe.herokuapp.com/api/noticias";
        
        private HttpClient _Client = new HttpClient();

        public NoticiaView()
        {
            Add = new Command(async () => {

                Noticia modelo = new Noticia()
                {

                    Titulo = Titulo,
                    Descripcion = Descripcion

                };

                string con = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(con, Encoding.UTF8, "application/json");
                System.Diagnostics.Debug.WriteLine(content.ToString());
                var result = await _Client.PostAsync(url, content);
                System.Diagnostics.Debug.WriteLine(con);
                var code = result.IsSuccessStatusCode;
                System.Diagnostics.Debug.WriteLine(code);


            }
          );

        }
    }
}
