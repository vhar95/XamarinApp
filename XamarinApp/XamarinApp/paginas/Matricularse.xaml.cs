using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Matricularse : ContentPage
    {
        private const string url = "https://apitwe.herokuapp.com/api/usuariocurso";
        //private const string url = "http://localhost:8000/api/usuariocurso";
        private HttpClient _Client = new HttpClient();

        public Matricularse(modelo.CurseClassesView curse)
        {
            InitializeComponent();
            BindingContext = curse;
        }

        private async void Insertar(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("curse id" + Int32.Parse(Idcurso.Text));
            System.Diagnostics.Debug.WriteLine("user id" + App.UserId);
            modelo.UserCurse modelo = new modelo.UserCurse()
            {
                Id_curso = Int32.Parse(Idcurso.Text),
                Id_usuario = App.UserId
            };

            
            string con = JsonConvert.SerializeObject(modelo);
            var content = new StringContent(con, Encoding.UTF8, "application/json");
            var result = await _Client.PostAsync(url, content);
            System.Diagnostics.Debug.WriteLine(con);
            var code = result.StatusCode.ToString();
            
            System.Diagnostics.Debug.WriteLine(code);

            if(code != "Created")
            {
                await DisplayAlert("Ya estas matriculado en este curso", "Dirigiendo a Cursos", "Ok", "Cancelar");
                await Navigation.PushAsync(new paginas.Cursos());
            }
            else
            {
                await DisplayAlert("Curso Asignado", "Dirigiendo a Mis Cursos", "Ok", "Cancelar");
                await Navigation.PushAsync(new paginas.MisCursos());
            }

            

        }
    }
}