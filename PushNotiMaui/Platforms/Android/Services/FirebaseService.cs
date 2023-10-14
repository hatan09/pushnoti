using Android.App;
using AndroidX.Core.App;
using Firebase.Messaging;

namespace PushNotiMaui.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        #region [ CTor ]
        public FirebaseService()
        {

        }
        #endregion

        #region [ Methods - Override ]
        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);

            if (Preferences.ContainsKey("DeviceToken"))
            {
                Preferences.Remove("DeviceToken");
            }
            Preferences.Set("DeviceToken", token);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var notification = message.GetNotification();
            if (notification != null)
            {
                OnPushNotification(notification.Title, notification.Body, message.Data);
            }
        }
        #endregion

        #region [ Methods - Notification ]
        private void OnPushNotification(string title, string body, IDictionary<string, string> data)
        {
            var builder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                .SetContentTitle(title)
                .SetContentText(body)
                .SetSmallIcon(Resource.Drawable.notification_template_icon_bg)
                .SetChannelId(MainActivity.CHANNEL_ID)
                .SetPriority(2);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(MainActivity.NOTIFICATION_ID, builder.Build());
        }
        #endregion
    }
}
