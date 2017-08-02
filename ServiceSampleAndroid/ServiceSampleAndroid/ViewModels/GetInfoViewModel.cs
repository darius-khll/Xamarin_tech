using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;
using ServiceSampleAndroid.Models;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;

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
                      await dbContext.Database.EnsureDeletedAsync();

                      //return;
                      await dbContext.Database.EnsureCreatedAsync();

                      await dbContext.Users.AddAsync(new User
                      {
                          Name = "ali",
                          Number = "+98" + TelephoneNumber
                      });

                      await dbContext.SaveChangesAsync();

                      await Page.DisplayAlert("ثبت", "شماره مورد نظر با موفقیت ثبت گردید", "باشه!");
                  }
              });
        }
    }
}
