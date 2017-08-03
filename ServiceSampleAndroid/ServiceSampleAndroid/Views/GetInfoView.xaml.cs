using System.Linq;
using ServiceSampleAndroid.Models;
using ServiceSampleAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceSampleAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetInfoView : ContentPage
    {
        public GetInfoView()
        {
            InitializeComponent();

            string telNumber = "9120000000";
            using (AppDbContext dbContext = new AppDbContext())
            {
                User user = dbContext.Users.FirstOrDefault();
                if(user != null)
                {
                    telNumber = user.Number;
                }
                  
            }

            BindingContext = new GetInfoViewModel { Page = this, TelephoneNumber = telNumber };

        }
    }
}