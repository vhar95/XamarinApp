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

            var page1 = new menuItems.MasterPageItem() { Title = "Mi Perfil", Icon = "perfil.png", TargetType = typeof(paginas.MiPerfil) };
            var page2 = new menuItems.MasterPageItem() { Title = "Contacto", Icon = "contacto.png", TargetType = typeof(paginas.Contacto) };
            var page3 = new menuItems.MasterPageItem() { Title = "Cerrar Sesión", Icon = "out.png", TargetType = typeof(paginas.LogOut) };
            var page4 = new menuItems.MasterPageItem() { Title = "FAQ", Icon = "faq.png", TargetType = typeof(paginas.FAQ) };
            var page5 = new menuItems.MasterPageItem() { Title = "Cursos", Icon = "cursos.png", TargetType = typeof(paginas.Cursos) };
            var page6 = new menuItems.MasterPageItem() { Title = "Mis Cursos", Icon = "carpetas.png", TargetType = typeof(paginas.MisCursos) };
            var page7 = new menuItems.MasterPageItem() { Title = "Noticias", Icon = "noticias.png", TargetType = typeof(paginas.Noticias) };


            menuList.Add(page1);
            menuList.Add(page6);
            menuList.Add(page5);
            menuList.Add(page7);
            menuList.Add(page2);
            menuList.Add(page4);
            menuList.Add(page3);

            navigationDrawerList.ItemsSource = menuList;

            //Si se quita el navigationDrawerList, se mostrará la página Inicio
            //Por defecto, se mantiene activa la página Inicio
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(paginas.Inicio)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //item va a ser el Item que se ha seleccionado
            var item = (menuItems.MasterPageItem)e.SelectedItem;

            //Guardamos la página (recoge el TargetType de ese Item) donde nos llevará 
            //la aplicación si seleccionamos ese Item
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}