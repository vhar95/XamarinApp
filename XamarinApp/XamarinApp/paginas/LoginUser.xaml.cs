using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //private const string url = "http://localhost:8000/api/usuarios/login/";
        private const string url = "https://apitwe.herokuapp.com/api/usuarios/login/";
        
        private HttpClient _Client = new HttpClient();

        public LoginUser()
        {
            InitializeComponent();
            BindingContext = this;
            this.IsBusy = false;
        }

        private async void Principal_M(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryCorreo.Text))
            { 
                await DisplayAlert("Error", "Debe ingresar una dirección de correo electrónico.", "Ok");
                EntryCorreo.Focus();
                return;
            }

            if (!emailValidator.IsValid)
            {
                await DisplayAlert("Error", "Debe ingresar una dirección de correo electrónico válida.", "Ok");
                EntryCorreo.Focus();
                return;
            }

            if (string.IsNullOrEmpty (EntryPassword.Text))
            {
                await DisplayAlert("Error", "Debe ingresar su contraseña.", "Ok");
                EntryPassword.Focus();
                return;
            }

            this.IsBusy = true;
            overlay.IsVisible = true;

            var response = await _Client.GetAsync(url + EntryCorreo.Text + "/" + EntryPassword.Text);
            var code = response.IsSuccessStatusCode;
            System.Diagnostics.Debug.WriteLine(code);

            if (code != false)
            {
                var content = await _Client.GetStringAsync(url + EntryCorreo.Text + "/" + EntryPassword.Text);
                var get = JsonConvert.DeserializeObject<List<modelo.User>>(content);

                App.UserNombre = get[0].Nombre;
                App.UserCorreo = get[0].Correo;
                App.UserId = get[0].id;
                App.Admin = get[0].Admin;

                await DisplayAlert("Login Correcto", "Logueado.", "Ok");
                this.IsBusy = false;
                overlay.IsVisible = false;

                if(App.Admin == 1)
                {
                    await Navigation.PushAsync(new paginasAdmin.MenuPrincipalAdmin());
                }
                else
                {
                    await Navigation.PushAsync(new paginas.MenuPrincipal());
                }
            }
            else
            {
                await DisplayAlert("Error Logueando", "Correo o Contraseña incorrectos o no existen.", "Ok");
                this.IsBusy = false;
                overlay.IsVisible = false;
            }
        }
    }
}