using Android.App;
using Android.Content;
using AndroidX.AppCompat.App;

namespace Pokedex.Droid
{
[Activity(Theme = "@style/Pokedex.Splash", MainLauncher = true, NoHistory = true)]
public class SplashActivity : AppCompatActivity
{
    protected override void OnResume()
    {
        base.OnResume();

        StartActivity(new Intent(Application.Context, typeof(MainActivity)));
    }
}
}