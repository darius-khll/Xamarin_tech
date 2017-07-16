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
        static readonly string TAG = "X:" + typeof(SimpleStartedService).Name;
        static readonly int TimerWait = 4000;
        Timer timer;
        DateTime startTime;
        bool isStarted = false;

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
        void StartServiceInForeground()
        {
            var ongoing = new Notification(Resource.Drawable.Icon, "Notification");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);
            ongoing.SetLatestEventInfo(this, "Notification", "SimpleService is running in the foreground", pendingIntent);

            StartForeground((int)NotificationFlags.AutoCancel, ongoing);
        }
        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null.
            return null;
        }


        public override void OnDestroy()
        {
            UnregisterReceiver(SMSBroadcastReceiver);

            timer.Dispose();
            timer = null;
            isStarted = false;

            TimeSpan runtime = DateTime.UtcNow.Subtract(startTime);
            Log.Debug(TAG, $"Simple Service destroyed at {DateTime.UtcNow} after running for {runtime:c}.");
            base.OnDestroy();
        }

        void HandleTimerCallback(object state)
        {
            TimeSpan runTime = DateTime.UtcNow.Subtract(startTime);
            Log.Debug(TAG, $"This service has been running for {runTime:c} (since ${state}).");
        }
    }
}