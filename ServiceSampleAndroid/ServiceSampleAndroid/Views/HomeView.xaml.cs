using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSampleAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceSampleAndroid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		public HomeView ()
		{
			InitializeComponent ();
            BindingContext = new HomeViewModel { Navigation = Navigation };
		}
	}
}