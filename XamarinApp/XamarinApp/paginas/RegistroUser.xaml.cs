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
	public partial class RegistroUser : ContentPage
	{
		public RegistroUser ()
		{
			InitializeComponent ();
		}

        private async void Volver_Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}