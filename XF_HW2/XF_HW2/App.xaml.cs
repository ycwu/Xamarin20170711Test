using Prism.Unity;
using XF_HW2.Views;
using Xamarin.Forms;

namespace XF_HW2
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            //App.Current.MainPage = your new mailpage
            //App.Current.Properties["CurrMainPage"] = "P1";
            //App.Current.SavePropertiesAsync();
            //NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            if (App.Current.Properties.ContainsKey("IsLogin") && (bool)App.Current.Properties["IsLogin"]==true)
                NavigationService.NavigateAsync("MDPage/NaviPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            else
                NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<FavoritePage>();
            Container.RegisterTypeForNavigation<ProfilePage>();
            Container.RegisterTypeForNavigation<SetupPage>();
            Container.RegisterTypeForNavigation<ThemePage>();
            Container.RegisterTypeForNavigation<MDPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<SetupPage>();
        }
    }
}
