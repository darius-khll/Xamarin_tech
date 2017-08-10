using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace ServiceSampleAndroid.Droid
{
    [Activity (Label = "ServiceSampleAndroid", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

            //start background service
            StartService(new Intent(this, typeof(SimpleStartedService)));

            base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new ServiceSampleAndroid.App ());

        }
    }
}


