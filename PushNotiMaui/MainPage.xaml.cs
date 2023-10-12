namespace PushNotiMaui
{
    public partial class MainPage : ContentPage
    {
        private string _deviceToken;

        public MainPage()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("DeviceToken"))
            {
                this._deviceToken = Preferences.Get("DeviceToken", "");
            }
        }

        private async void OnPushNoti(object sender, EventArgs e)
        {
            string url = $"https://localhost:44379/api/pushnoti/firebase/{this._deviceToken}";

            using var client = new HttpClient();
            var response = await client.PostAsync(url, new StringContent(""));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Sucess", "Push Notification Sent!", "Close");
            }
        }
    }
}