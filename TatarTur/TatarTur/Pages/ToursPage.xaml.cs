using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatarTur.Sqlite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TatarTur.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToursPage : ContentPage
    {
        public City city = new City();
        public User user = new User();
        public Task<List<City>> cityList { get; set; }
        public ToursPage(User usr)
        {
            InitializeComponent();
            
            cityList = TablesRepos.GetCitiesAsync();

            user = usr;

            
            this.BindingContext = this;
            
        }
        protected override void OnAppearing()
        {
            ToursList.ItemsSource = App.Database.GetTours();
            base.OnAppearing();
        }

        private async void AddTour(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTourPage());
        }

        private async void TourList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Tour selectedTour = (sender as CollectionView).SelectedItem as Tour;
            CurrentTourPage currentCharacterPage = new CurrentTourPage(selectedTour, user);
            currentCharacterPage.BindingContext = selectedTour;
            await Navigation.PushAsync(new CurrentTourPage(selectedTour, user));
        }

       // private void Picker_SelectedIndexChanged(object sender, EventArgs e)
       // {
       //     city = cities.SelectedItem as City;
       //
       //     ToursList.ItemsSource = App.Database.GetTours().Where(x => x.IdCity == city.Id).ToList();
       // }
    }
}