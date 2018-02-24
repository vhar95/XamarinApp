using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class CurseClassesView: CurseClasses
    {

        private CurseClassesView _selectedItem { get; set; }
        public CurseClassesView SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                App.Current.MainPage.Navigation.PushAsync(new paginas.Prueba(_selectedItem));
            }
        }

        public CurseClassesView()
        {


            
        }
    }
}
