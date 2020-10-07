using Plugin.BreachDetector;
using Xamarin.Forms;

namespace CheckRootOrJailbreak
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        private void CheckRootOrJailbreak()
        {
            bool isRootOrJailbreak = CrossBreachDetector.Current.IsRooted().GetValueOrDefault();
            if (!isRootOrJailbreak)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("", "Not supported on Rooted Devices", "Ok");

                    // Kill process
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                });
            }
        }

        protected override void OnStart()
        {
            CheckRootOrJailbreak();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
