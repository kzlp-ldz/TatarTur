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
    public partial class CurrentTourPage : ContentPage
    {
        public Tour tour = new Tour();
        User user = new User();
        public CurrentTourPage(Tour tr, User usr)
        {
            InitializeComponent();
            tour = tr;
            user = usr;

            nameTour.Text = tour.Name;
            cityTour.Text = App.Database.GetCity(tour.IdCity).Name;
            ratingTour.Text = tour.Rating.ToString();
            TourPhoto.Source = tour.PhotoPath;
            descriptionTour.Text = tour.Description;


            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            ReviewsList.ItemsSource = App.Database.GetReviewId(tour.Id);
            base.OnAppearing();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        private async void AddReviewTour(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new AddReviewPage(tour, user));
        }
        private async void GoToSiteTour(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(tour.uri);
        }
    }
}