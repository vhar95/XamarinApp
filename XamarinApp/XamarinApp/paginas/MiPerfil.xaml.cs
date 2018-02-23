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
    public partial class MiPerfil : ContentPage
    {
        //private const string url = "http://localhost:8000/api/usuarios/";
        private const string url = "https://apitwe.herokuapp.com/api/usuarios/";
        
        private HttpClient _Client = new HttpClient();
        

        public MiPerfil()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
        }


        protected override async void OnAppearing()
        {
            IsBusy = true;
            var content = await _Client.GetStringAsync(url + App.UserId);
            modelo.UserView get = JsonConvert.DeserializeObject<modelo.UserView>(content);
            BindingContext = get;
            base.OnAppearing();
            IsBusy = false;
           
        }
    }
}