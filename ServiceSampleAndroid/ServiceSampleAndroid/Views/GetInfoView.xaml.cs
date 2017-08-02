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
    public partial class GetInfoView : ContentPage
    {
        public GetInfoView()
        {
            InitializeComponent();
            BindingContext = new GetInfoViewModel { Page = this };
        }
    }
}