namespace PushNotiMaui.Models
{
    public class PushNotificationRequest
    {
        public List<string> RegistrationIds { get; set; } = new List<string>();
        public NotificationMessageBody Notification { get; set; }
        public object Data { get; set; }
    }

    public class NotificationMessageBody
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
