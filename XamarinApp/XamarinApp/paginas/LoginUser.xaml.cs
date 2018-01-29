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
	public partial class LoginUser : ContentPage
	{
		public LoginUser ()
		{
			InitializeComponent ();
		}

        private async void Principal_M(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new paginas.MenuPrincipal());
        }
    }
}