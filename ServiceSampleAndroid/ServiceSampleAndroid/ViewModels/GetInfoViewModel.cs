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
        public Page Page { get; set; }

        public string TelephoneNumber { get; set; }

        public Command SaveIntoDB { get; set; }

        public GetInfoViewModel()
        {
            SaveIntoDB = new Command(async () =>
              {
                  using (AppDbContext dbContext = new AppDbContext())
                  {
                      //await dbContext.Database.EnsureDeletedAsync();
                      //await dbContext.Database.EnsureCreatedAsync();

                      User deletedUser = await dbContext.Users.FirstOrDefaultAsync();
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
        }
    }
}
