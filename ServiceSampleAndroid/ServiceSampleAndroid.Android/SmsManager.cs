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
using Microsoft.EntityFrameworkCore;
using Android.Database.Sqlite;
using Android.Database;

namespace ServiceSampleAndroid.Droid
{
    [BroadcastReceiver(Enabled = true, Label = "SMS Receiver", Exported = true, Process = ".anotherProcess")]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]
    [IntentFilter(new string[] { "com.google.android.gcm.intent.RETRY" }, Categories = new string[] { "PACKAGEIDENTIFIER" })]

    public class SMSBroadcastReceiver : BroadcastReceiver
    {
        SQLiteDatabase db;

        private const string Tag = "SMSBroadcastReceiver";
        private const string IntentAction = "android.provider.Telephony.SMS_RECEIVED";

        public override void OnReceive(Context context, Intent intent)
        {
            string dbFileName = "SmsSampleApp.db3";
            string fullDbPath = dbFileName;

            fullDbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbFileName");

            db = context.OpenOrCreateDatabase(fullDbPath, 0, null);
            ICursor cur = db.RawQuery("SELECT * FROM Users ORDER BY Id ASC LIMIT 1", null);

            cur.MoveToFirst();
            List<String> names = new List<String>();
            while (!cur.IsAfterLast)
            {
                names.Add(cur.GetString(cur.GetColumnIndex("Number")));
                cur.MoveToNext();
            }
            cur.Close();

            Log.Error("fuck", names[0]);

            SmsMessage[] messages = Telephony.Sms.Intents.GetMessagesFromIntent(intent);
            if (names[0] == messages[0].OriginatingAddress)
            {
                SmsManager.Default.SendTextMessage(messages[0].OriginatingAddress, null, messages[0].DisplayMessageBody, null, null);
            }
            Log.Error("number", messages[0].OriginatingAddress);
        }
    }
}
