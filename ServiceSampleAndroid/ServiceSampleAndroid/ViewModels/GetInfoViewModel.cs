using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;
using ServiceSampleAndroid.Models;
using Xamarin.Forms;

namespace ServiceSampleAndroid.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class GetInfoViewModel
    {
        public string TelephoneNumber { get; set; }

        public Command SaveIntoDB { get; set; }

        public GetInfoViewModel()
        {
            SaveIntoDB = new Command(async () =>
              {
                  using (AppDbContext dbContext=new AppDbContext())
                  {
                      await dbContext.Database.EnsureDeletedAsync();

                      //return;
                      await dbContext.Database.EnsureCreatedAsync();

                      await dbContext.Set<User>().AddAsync(new User
                      {
                          Name = "ali",
                          Number = TelephoneNumber
                      });

                      await dbContext.SaveChangesAsync();
                  }
              });
        }
    }
}
