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
            await Navigation.PushAsync(new paginas.Noticias());
        }
    }
}