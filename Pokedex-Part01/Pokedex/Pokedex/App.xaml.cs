using Pokedex.Resources;
using Pokedex.Views;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace Pokedex
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);

            MainPage = new NavigationPage(new OverviewPage());
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
