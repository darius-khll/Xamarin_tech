using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Telephony;
using Android.Util;
using Android.Views;
using Android.Widget;
using ServiceSampleAndroid.Models;

namespace ServiceSampleAndroid.Droid
{
    [BroadcastReceiver(Enabled = true, Label = "SMS Receiver", Exported = true, Process = ".anotherProcess")]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.gcm.intent.RETRY" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]

    public class SMSBroadcastReceiver : BroadcastReceiver
    {

        private const string Tag = "SMSBroadcastReceiver";
        private const string IntentAction = "android.provider.Telephony.SMS_RECEIVED";

        public override void OnReceive(Context context, Intent intent)
        {
            User users = new User();

            //PowerManager.WakeLock sWakeLock;
            //var pm = PowerManager.FromContext(context);
            //sWakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "GCM Broadcast Reciever Tag");
            //sWakeLock.Acquire();
            //sWakeLock.Release();
            //Log.Info(Tag, "Intent received: " + intent.Action);

            //if (intent.Action != IntentAction) return;

            //using (AppDbContext dbContext = new AppDbContext())
            //{
            //    User user = dbContext.Set<User>().FirstOrDefault();
            //}

            SmsMessage[] messages = Telephony.Sms.Intents.GetMessagesFromIntent(intent);

            SmsManager.Default.SendTextMessage(messages[0].OriginatingAddress, null, messages[0].MessageBody, null, null);
            var sb = new StringBuilder();

            for (var i = 0; i < messages.Length; i++)
            {
                sb.Append(string.Format("SMS From: {0}{1}Body: {2}{1}", messages[i].OriginatingAddress,
                    System.Environment.NewLine, messages[i].MessageBody));
            }

        }
    }
}
