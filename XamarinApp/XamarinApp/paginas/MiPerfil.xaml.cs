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
    public partial class MiPerfil : ContentPage
    {
        //private const string url = "http://localhost:8000/api/usuarios/";
        private const string url = "https://apitwe.herokuapp.com/api/usuarios/";
        
        private HttpClient _Client = new HttpClient();
        

        public MiPerfil()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
        }


        protected override async void OnAppearing()
        {
            IsBusy = true;
            overlay.IsVisible = true;
            var content = await _Client.GetStringAsync(url + App.UserId);
            modelo.UserView get = JsonConvert.DeserializeObject<modelo.UserView>(content);
            IsBusy = false;
            overlay.IsVisible = false;
            BindingContext = get;
            base.OnAppearing();
        }

        private async void Validar_Campos(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Nameee.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos su nombre.", "Ok");
                Nameee.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Surnameee.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuáles son sus apellidos.", "Ok");
                Surnameee.Focus();
                return;
            }

            if (string.IsNullOrEmpty(elNickkk.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuál será su nuevo Nick de Usuario.", "Ok");
                elNickkk.Focus();
                return;
            }

            if (pickerSexooo.SelectedIndex == -1)
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuál es su sexo.", "Ok");
                pickerSexooo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(correoEEE.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, introduzca una dirección de correo electrónico.", "Ok");
                correoEEE.Focus();
                return;
            }

            if (!emailValidatorrr.IsValid)
            {
                await DisplayAlert("Correo inválido", "Por favor, especifique una dirección de correo electrónico válida.", "Ok");
                correoEEE.Focus();
                return;
            }
                                   
            if (string.IsNullOrEmpty(Phoneee.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos su número de teléfono.", "Ok");
                Phoneee.Focus();
                return;
            }

            if (Phoneee.Text.Length < 9)
            {
                await DisplayAlert("Número de teléfono inválido", "El número de teléfono debe tener al menos 9 dígitos.", "Ok");
                Phoneee.Focus();
                return;
            }

            if (string.IsNullOrEmpty(skypeUserrr.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos su nombre de Usuario de Skype.", "Ok");
                skypeUserrr.Focus();
                return;
            }

            if (pickerNivelll.SelectedIndex == -1)
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuál es su nivel de inglés actual.", "Ok");
                pickerNivelll.Focus();
                return;
            }

            modelo.UserView m = this.BindingContext as modelo.UserView;
            if ((m != null) && (m.Update.CanExecute(null)))
            {
                m.Update.Execute(null);
                //await DisplayAlert("Hecho!!", "Sus datos se han actualizado correctamente.", "Volver al Menú Principal");
                //await Navigation.PushAsync(new MainPage());

            }
            
            
        }
    }
}