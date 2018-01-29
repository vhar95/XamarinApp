using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Nuevo_User(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new paginas.RegistroUser());
        }

         private async void Ex_User(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new paginas.LoginUser());
        }
    }
}
