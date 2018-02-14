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
    public partial class LoginUser : ContentPage
    {
        private const string url = "http://localhost:8000/api/usuarios/login/";
        private HttpClient _Client = new HttpClient();

        public LoginUser()
        {
            InitializeComponent();
        }

        private async void Principal_M(object sender, EventArgs e)
        {

            var response = await _Client.GetAsync(url + EntryCorreo.Text + "/" + EntryPassword.Text);

            var code = response.IsSuccessStatusCode;
            System.Diagnostics.Debug.WriteLine(code);

            if (code != false)
            {
                
                await DisplayAlert("Login Correcto", "Logeado", "Ok", "Cancelar");
                await Navigation.PushAsync(new paginas.MenuPrincipal());
            }
            else
            {
                await DisplayAlert("Error Logueando", "Correo o Contraseña incorrectos o no existe", "Ok", "Cancelar");
            }
        }
    }
}