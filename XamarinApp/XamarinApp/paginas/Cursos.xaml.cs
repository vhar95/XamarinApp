using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.paginas
{
   

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cursos : ContentPage
	{
        //private const string url = "http://localhost:8000/api/cursos";
        private const string url = "https://apitwe.herokuapp.com/api/cursos";
        
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<modelo.CurseClassesView> _post;
        
        public Cursos ()
		{
			InitializeComponent ();

            BindingContext = new modelo.CurseClassesView();

            Post_List.ItemSelected += async (sender, e) =>
            {
                modelo.CurseClassesView m = (modelo.CurseClassesView)e.SelectedItem;
                await Navigation.PushAsync(new paginas.Prueba(m));
                
                
            };

        }

        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<modelo.CurseClassesView>>(content);
            _post = new ObservableCollection<modelo.CurseClassesView>(post);
            Post_List.ItemsSource = _post;
            base.OnAppearing();
        }

        
    }
}