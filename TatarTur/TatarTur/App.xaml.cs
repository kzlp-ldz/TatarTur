using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TatarTur.Sqlite;
using System.IO;
using TatarTur.Pages;

namespace TatarTur
{
    
    public partial class App : Application
    {
        public const string DATABASE_NAME = "tours.db";
        public static TablesRepos database;
        public static TablesRepos Database
        {
            get
            {
                if (database == null)
                {
                    database = new TablesRepos(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            if (App.Database.IsNewUser())
            {
                App.Database.CityTemplate();
                MainPage = new NavigationPage(new Pages.AutoPage());
            }
            else
                MainPage = new NavigationPage(new Pages.AutoPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
