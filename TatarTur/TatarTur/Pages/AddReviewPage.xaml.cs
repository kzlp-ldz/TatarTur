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
    public partial class AddReviewPage : ContentPage
    {
        Tour tour = new Tour();
        User user = new User();
        public AddReviewPage(Tour tr, User usr)
        {
            InitializeComponent();

            user = usr;
            tour = tr;

            this.BindingContext = this;
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        
        private async void SaveReview(object sender, EventArgs e)
        {
            Review review = new Review()
            {
                Description = reviewDescript.Text,
                IdUser = user.Id,
                IdTour = tour.Id,
            };
            if (!String.IsNullOrEmpty(review.Description))
            {
                App.Database.SaveReview(review);
            }
            await this.Navigation.PopAsync();
        }
    }
}