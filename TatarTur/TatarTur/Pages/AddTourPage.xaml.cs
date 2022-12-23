using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatarTur.Sqlite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TatarTur.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTourPage : ContentPage
    {
        public List<City> cityList { get; set; }
        public City city = new City();
        public string pathName;
       // public AddTourPage()
       // {
       //     InitializeComponent();
       //     cityList = new List<City>();
       //     cityList = App.Database.GetCities();
       //     this.BindingContext = this;
       // }
        private async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
            UpdateList();
        }
        private void UpdateList()
        {
            TourPhoto.Source = pathName;
            this.BindingContext = this;
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            city = cities.SelectedItem as City;
        }
       // private async void SaveTour(object sender, EventArgs e)
       // {
       //     Tour tour = new Tour()
       //     {
       //         Name = nameTour.Text,
       //         IdCity = city.Id,
       //         Rating = double.Parse(ratingTour.Text),
       //         Description = descriptionTour.Text,
       //         uri = new Uri(urlTour.Text),
       //         PhotoPath = pathName,
       //     };
       //     if (!String.IsNullOrEmpty(tour.Name))
       //     {
       //         App.Database.SaveTour(tour);
       //     }
       //     await this.Navigation.PopAsync();
       // }
    }
}