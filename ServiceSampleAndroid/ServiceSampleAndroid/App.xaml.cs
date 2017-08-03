using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceSampleAndroid.Models;
using Xamarin.Forms;

namespace ServiceSampleAndroid
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ServiceSampleAndroid.Views.HomeView());
		}

		protected override void OnStart ()
		{
            using (AppDbContext db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
