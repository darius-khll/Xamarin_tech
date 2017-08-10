using System.Linq;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using ServiceSampleAndroid.Models;
using Xamarin.Forms;

namespace ServiceSampleAndroid.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class GetInfoViewModel
    {
        public INavigation Navigation { get; set; }

        public Page Page { get; set; }

        public string TelephoneNumber { get; set; }

        public Command SaveIntoDB { get; set; }
        public Command GoBackToHomePage { get; set; }

        public GetInfoViewModel()
        {
            SaveIntoDB = new Command(async () =>
              {
                  using (AppDbContext dbContext = new AppDbContext())
                  {
                      User deletedUser = await dbContext.Users.FirstOrDefaultAsync();
                      if(deletedUser != null)
                        dbContext.Users.Remove(deletedUser);

                      await dbContext.Users.AddAsync(new User
                      {
                          Name = "ali",
                          Number = TelephoneNumber.StartsWith("+98") ? TelephoneNumber : "+98" + TelephoneNumber
                      });

                      await dbContext.SaveChangesAsync();

                      await Page.DisplayAlert("ثبت", "شماره مورد نظر با موفقیت ثبت گردید", "باشه!");
                  }
              });

            GoBackToHomePage = new Command(async () =>
            {
                await Navigation.PopAsync(false);
            });

        }
    }
}
