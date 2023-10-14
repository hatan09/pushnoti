namespace PushNotiMaui
{
    public partial class MainPage : ContentPage
    {
        private string _deviceToken = "";

        public MainPage()
        {
            InitializeComponent();

            var token = Preferences.Get("DeviceToken", string.Empty);
            this._deviceToken = token;

            // For testing: grab this token and use Postman to request the api server to send notification to this device
            Console.WriteLine($"DeviceToken: {this._deviceToken}");
        }

        private async void OnPushNoti(object sender, EventArgs e)
        {
            try
            {
                string url = $"https://localhost:44379/api/pushnoti/firebase/{this._deviceToken}"; //server api

                using var client = new HttpClient();

                //api server auth
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = await client.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await App.Current.MainPage.DisplayAlert("Sucess", "Push Notification Sent!", "Close");
                }
                else
                {
                    Console.WriteLine(response.StatusCode.ToString());
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}