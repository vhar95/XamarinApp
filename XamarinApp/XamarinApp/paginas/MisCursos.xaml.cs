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
    public partial class MisCursos : ContentPage
    {
        //private const string url = "http://localhost:8000/api/usuariocurso/comprobar";
        private const string url = "https://apitwe.herokuapp.com/api/usuariocurso/comprobar";

        private HttpClient _Client = new HttpClient();
        private ObservableCollection<modelo.CurseView> _post;

        public MisCursos()
        {
            InitializeComponent();
            BindingContext = this;
            this.IsBusy = false;

        }

        protected override async void OnAppearing()
        {
            IsBusy = true;
            overlay.IsVisible = true;
            var response = await _Client.GetAsync(url + "/" + App.UserId);
            var code = response.IsSuccessStatusCode;
            
            if(code != false)
            {
                
                var content = await _Client.GetStringAsync(url+"/"+App.UserId);
                var post = JsonConvert.DeserializeObject<List<modelo.CurseView>>(content);
                _post = new ObservableCollection<modelo.CurseView>(post);
                Post_List.ItemsSource = _post;
                
            }
            else
            {
                cursosno.IsVisible = true;
            }
            IsBusy = false;
            overlay.IsVisible = false;
            base.OnAppearing();
        }
    }
}