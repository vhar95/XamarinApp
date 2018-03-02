using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistroUser : ContentPage
	{
		public RegistroUser ()
		{
			InitializeComponent ();
            this.BindingContext = new modelo.UserView();
            
        }

        private async void Volver_Login(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos su nombre.", "Ok");
                Name.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Surname.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuáles son sus apellidos.", "Ok");
                Surname.Focus();
                return;
            }

            if (string.IsNullOrEmpty(elNick.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuál será su Nick de Usuario.", "Ok");
                elNick.Focus();
                return;
            }

            if (pickerSexo.SelectedIndex == -1)
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuál es su sexo.", "Ok");
                pickerSexo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(correoE.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos su correo electrónico.", "Ok");
                correoE.Focus();
                return;
            }

            if (!emailValidator.IsValid)
            {
                await DisplayAlert("Correo inválido", "Debe ingresar una dirección de correo electrónico válida.", "Ok");
                correoE.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Passwordd.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, introduzca su contraseña.", "Ok");
                Passwordd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Phone.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos su número de teléfono.", "Ok");
                Phone.Focus();
                return;
            }
            
            if (Phone.Text.Length < 9)
            {
                await DisplayAlert("Número de teléfono inválido", "El número de teléfono debe tener al menos 9 dígitos.", "Ok");
                Phone.Focus();
                return;
            }

            if (string.IsNullOrEmpty(skypeUser.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos su nombre de Usuario de Skype.", "Ok");
                skypeUser.Focus();
                return;
            }

            if (pickerNivel.SelectedIndex == -1)
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, indíquenos cuál es su nivel de inglés actual.", "Ok");
                pickerNivel.Focus();
                return;
            }


            modelo.UserView m = this.BindingContext as modelo.UserView;
            if ((m != null) && (m.Guardar.CanExecute(null)))
            {
                m.Guardar.Execute(null);
                await DisplayAlert("¡¡¡Enhorabuena!!!", "Ya eres TWENIX!!", "Volver al Menú Principal");
                await Navigation.PushAsync(new MainPage());
            }


        }

    }
}