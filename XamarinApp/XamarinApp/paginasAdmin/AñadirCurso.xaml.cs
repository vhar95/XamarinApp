using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.paginasAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AñadirCurso : ContentPage
    {
        

        public AñadirCurso()
        {
            InitializeComponent();
            this.BindingContext = new modelo.CurseClassesView();
        }

        private async void Añadir_Volver(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cursillo.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, introduzca el nombre del nuevo curso.", "Ok");
                cursillo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(durationnn.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, introduzca la duración del curso (en meses).", "Ok");
                durationnn.Focus();
                return;
            }

            modelo.CurseClassesView m = this.BindingContext as modelo.CurseClassesView;
            if ((m != null) && (m.Add.CanExecute(null)))
            {
                m.Add.Execute(null);
                await DisplayAlert("Curso Añadido Correctamente", "", "OK");

                await Navigation.PushAsync(new NavigationPage((Page)Activator.CreateInstance(typeof(CursosAdmin))));
            }
            
        }
    }
}