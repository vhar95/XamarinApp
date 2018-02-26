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
            await Navigation.PushAsync(new paginasAdmin.CursosAdmin());
        }
    }
}