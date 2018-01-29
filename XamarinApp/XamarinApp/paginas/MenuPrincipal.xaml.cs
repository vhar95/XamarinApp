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

            var page1 = new menuItems.MasterPageItem() { Title = "Mi perfil", Icon = "itemIcon1.png", TargetType = typeof(paginas.Test) };
            var page2 = new menuItems.MasterPageItem() { Title = "Contacto", Icon = "itemIcon2.png", TargetType = typeof(paginas.Test) };

            menuList.Add(page1);
            menuList.Add(page2);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(paginas.Test)));
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