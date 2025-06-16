using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.OS;
using Plugin.MauiMTAdmob;

namespace Pub
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Initialisation AdMob
            MobileAds.Initialize(this);
            CrossMauiMTAdmob.Current.Init(this, "ca-app-pub-6237852957066712~9670577047");

            // Autres codes ...
        }
    }
}
