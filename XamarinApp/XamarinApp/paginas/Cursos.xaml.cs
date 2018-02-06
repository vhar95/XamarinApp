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
	public partial class Cursos : ContentPage
	{
        modelo.CurseClassesView cuv;
		public Cursos ()
		{
			InitializeComponent ();
            cuv = new modelo.CurseClassesView();
            list.ItemsSource = cuv.CursesClasses;
        }
	}
}