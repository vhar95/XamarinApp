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
    public partial class LogOut : ContentPage
    {
        public LogOut()
        {
            InitializeComponent();
        }

        private void Cerrar_Sesion(object sender, EventArgs e)
        {
            App.UserId = 0;
            App.UserCorreo = "";
            App.UserNombre = "";
            App.Current.MainPage = new MainPage();
        }
    }
}