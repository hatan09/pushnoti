# pushnoti
## Concepts:
1. How does it work?
   - A notification is a message sent from the notification provider to a device which registered and is listening to that provider server (Firebase).
   - Custom Api can send request to the notificaiton provider to notify device(s) using Sdks (Firebase Admin Sdk).
   - The clients are end users devices which need to register to the provider, configure receiving notification handlers...Clients can request the WebApi server to send notification.
   - Notification Channel (?).
   - Notification topic (?).
   - Notification data (?)

2. Components:
   - Firebase project: a solution for notification provider.
   - Service account: a princpal on behalf of user to authenticate Firebase services.
   - Admin Sdk: Firebase cloud messaging (FCM) library helps authentication and sending notification requests to Firebase. `FirebaseAdmin` Nuget is for .Net.
   - `FirebaseMessaging.DefaultInstance`: to get the Admin Sdk notification handler.
   - `FirebaseMessagingService`: handles registration and receiving notificaitons.

## Implementation
### PushNotiApi
- This will make call to the Firebase server to trigger push notification.
- Exposed url: [GET] your-url/api/pushnoti/firebase/{deviceToken}.

**Steps**
1. Add ASP.Net WebApi project
2. Install `FirebaseAdmin` Nuget
3. Download the json containing service account's authentication info from Firebase project settings.
4. Add the json content to appsettings.json.
5. Authenticate & create the Admin Sdk in `Program.cs`
6. `FirebaseMessaging.DefaultInstance.SendAsync()` to send notification.

<br/>

### PushNotiMaui
- This will listen to Firebase server to receive push notification.
- It will send request to the Api to trigger a notification to the running device. The Api url needed to be provided.

**Steps**
1. Add ASP.Net Maui project
2. Install necessary libraries.
3. Create new application (Android) and download the license (google-services.json) file from Firebase. Place it under Platforms > Android.
4. Add a service extends `FirebaseMessagingService` and override `OnNewToken()`, `OnMessageReceived()`. Export this module (?)
5. Create notificaiton channels in Android > `MainActivity.cs`.
6. Add logic to a page (MainPage) to trigger Api server.
