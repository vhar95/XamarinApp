using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Noticias : ContentPage
    {
        //private const string url = "http://localhost:8000/api/noticias";
        private const string url = "https://apitwe.herokuapp.com/api/noticias";

        private HttpClient _Client = new HttpClient();
        private ObservableCollection<modelo.NoticiaView> _post;
        public Noticias()
        {
            InitializeComponent();
            BindingContext = this;
            this.IsBusy = false;
            overlay.IsVisible = false;
        }

        protected override async void OnAppearing()
        {
            IsBusy = true;
            overlay.IsVisible = true;
            var response = await _Client.GetAsync(url);
            var code = response.IsSuccessStatusCode;
            System.Diagnostics.Debug.WriteLine("noticia"+code);
            if (code != false)
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<modelo.NoticiaView>>(content);
                _post = new ObservableCollection<modelo.NoticiaView>(post);
                Post_List.ItemsSource = _post;
            }
            else
            {
                noticiasno.IsVisible = true;
            }

            
            base.OnAppearing();
            IsBusy = false;
            overlay.IsVisible = false;
        }
    }
}