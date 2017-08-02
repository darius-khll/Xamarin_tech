using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace ServiceSampleAndroid.Droid
{
    [Service]
    public class SimpleStartedService : Service
    {
        public override void OnCreate()
        {
            base.OnCreate();
        }
        public SMSBroadcastReceiver SMSBroadcastReceiver;
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            IntentFilter filter = new IntentFilter(Intent.ActionQuickClock);

            

            filter.AddAction("android.provider.Telephony.SMS_RECEIVED");

            RegisterReceiver(SMSBroadcastReceiver, filter);

            return StartCommandResult.Sticky;

        }
        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null.
            return null;
        }


        public override void OnDestroy()
        {
            UnregisterReceiver(SMSBroadcastReceiver);

            base.OnDestroy();
        }
    }
}