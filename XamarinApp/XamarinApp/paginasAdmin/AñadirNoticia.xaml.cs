using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.paginasAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AñadirNoticia : ContentPage
    {
        public AñadirNoticia()
        {
            InitializeComponent();
            this.BindingContext = new modelo.NoticiaView();
        }

        private async void Añadir_Volver(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(noticiaaa.Text))
            {
                await DisplayAlert("Existen campos obligatorios vacíos", "Por favor, introduzca el título de la nueva noticia.", "Ok");
                noticiaaa.Focus();
                return;
            }

            modelo.NoticiaView m = this.BindingContext as modelo.NoticiaView;
            if ((m != null) && (m.Add.CanExecute(null)))
            {
                m.Add.Execute(null);
                await DisplayAlert("Noticia Añadida Correctamente", "", "OK");
                await Navigation.PushAsync(new paginas.Noticias());
            }
            
        }
    }
}