using AccountingNavid.DataLayer.Cummon.Helpers;
using AccountingNavid.DataLayer.Services;
using AccountingNavid.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Vazir-Black-FD-WOL.ttf", Alias = "FarsiFont")]
namespace AccountingNavid
{
    public partial class App : Application
    {
        public static ViewModel.MainViewModel ViewModel { get; set; }
        public static INavigation MainNavigation { get; set; }
        private static AppDatabase database;
        public static AppDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new AppDatabase(GeneralHelper.GetLocalFilePath("AppDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HomePage());
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromRgb(0, 183, 187);
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
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
