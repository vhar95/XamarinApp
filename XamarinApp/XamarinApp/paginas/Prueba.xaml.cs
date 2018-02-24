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
	public partial class Prueba : ContentPage
	{
		public Prueba (modelo.CurseClassesView curso)
		{
			InitializeComponent ();
            BindingContext = curso;
		}
	}
}