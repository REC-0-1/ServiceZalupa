using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Service
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Проверка версии Android
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                // Запрос разрешений для камеры
                if (CheckSelfPermission(Manifest.Permission.Camera) != Permission.Granted)
                {
                    RequestPermissions(new string[] { Manifest.Permission.Camera }, 1);
                }
            }
        }
    }
}
