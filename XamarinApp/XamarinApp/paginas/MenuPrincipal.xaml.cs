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
	public partial class MenuPrincipal : MasterDetailPage
	{
        public List<menuItems.MasterPageItem> menuList { get; set; }
        public MenuPrincipal ()
		{
			InitializeComponent ();
            menuList = new List<menuItems.MasterPageItem>();

            var page1 = new menuItems.MasterPageItem() { Title = "Mi perfil", Icon = "perfil.png", TargetType = typeof(paginas.MiPerfil) };
            var page2 = new menuItems.MasterPageItem() { Title = "Contacto", Icon = "contacto.png", TargetType = typeof(paginas.Test) };
            var page3 = new menuItems.MasterPageItem() { Title = "Cerrar Sesión", Icon = "out.png", TargetType = typeof(paginas.Test) };
            var page4 = new menuItems.MasterPageItem() { Title = "Faq", Icon = "faq.png", TargetType = typeof(paginas.Test) };
            var page5 = new menuItems.MasterPageItem() { Title = "Cursos", Icon = "cursos.png", TargetType = typeof(paginas.Cursos) };
            var page6 = new menuItems.MasterPageItem() { Title = "Mis Cursos", Icon = "carpetas.png", TargetType = typeof(paginas.MisCursos) };
            var page7 = new menuItems.MasterPageItem() { Title = "Noticias", Icon = "noticias.png", TargetType = typeof(paginas.Test) };


            menuList.Add(page1);
            menuList.Add(page6);
            menuList.Add(page5);
            menuList.Add(page7);
            menuList.Add(page2);
            menuList.Add(page4);
            menuList.Add(page3);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(paginas.Inicio)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (menuItems.MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}