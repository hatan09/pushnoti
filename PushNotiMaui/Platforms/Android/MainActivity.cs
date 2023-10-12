using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;

namespace PushNotiMaui
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        #region [ Fields ]
        internal static readonly string Channel_ID = "TestChannel";
        internal static readonly int NotificationID = 101;
        #endregion

        #region [ Methods - Override ]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            OnCreatingNotiService();
        }
        #endregion

        #region [ Methods - Create Noti ]
        private void OnCreatingNotiService()
        {
            if (OperatingSystem.IsOSPlatformVersionAtLeast("android", 26))
            {
                var channel = new NotificationChannel(Channel_ID, "Test Notfication Channel", NotificationImportance.Default);

                var notificaitonManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
                notificaitonManager.CreateNotificationChannel(channel);
            }
        }
        #endregion
    }
}