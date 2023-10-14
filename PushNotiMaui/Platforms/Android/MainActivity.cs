using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PushNotiMaui
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        #region [ Fields ]
        public static readonly string CHANNEL_ID = "TestChannel";
        public static readonly int NOTIFICATION_ID = 1;
        #endregion

        #region [ Methods - Override ]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CreateNotificationChannel();
        }
        #endregion

        #region [ Methods - Create ]
        private void CreateNotificationChannel()
        {
            if(OperatingSystem.IsOSPlatformVersionAtLeast("android", 26))
            {
                var testChannel = new NotificationChannel(CHANNEL_ID, "Test Channel", NotificationImportance.Default);

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(testChannel);
            }
        }
        #endregion
    }
}