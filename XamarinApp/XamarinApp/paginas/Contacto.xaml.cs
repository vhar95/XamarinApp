using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contacto : ContentPage
    {
        public Contacto()
        {
            InitializeComponent();
        }

        private async void Acceder_FAQ(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new FAQ());
        }
    }
}