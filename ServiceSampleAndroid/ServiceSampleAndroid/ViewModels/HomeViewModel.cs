using PropertyChanged;
using ServiceSampleAndroid.Views;
using Xamarin.Forms;

namespace ServiceSampleAndroid.ViewModels
{
    [AddINotifyPropertyChangedInterface] //Fody
    public class HomeViewModel
    {
        public INavigation Navigation { get; set; }

        public Command GoToInfoPage { get; set; }

        public HomeViewModel()
        {
            GoToInfoPage = new Command(async () =>
            {
                await Navigation.PushAsync(new GetInfoView());
            });
        }
    }
}
