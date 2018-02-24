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
    public partial class Matricularse : ContentPage
    {
        public Matricularse(modelo.CurseClassesView curse)
        {
            InitializeComponent();
            BindingContext = curse;
        }
    }
}