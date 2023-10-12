using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace PushNotiApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotiController : ControllerBase
    {
        [HttpPost("firebase/{deviceToken}")]
        public async Task<IActionResult> SendFirebaseNotiAsync([FromBody] string info, string deviceToken)
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "Notification Title",
                    Body = $"Your number is: {Random.Shared.Next(0, 100)}",
                },
                Data = new Dictionary<string, string> {
                    ["Infomation"] = string.IsNullOrEmpty(info) ? "No information." : info,
                },
                Token = deviceToken,
            };

            var notiHandler = FirebaseMessaging.DefaultInstance;
            await notiHandler.SendAsync(message);

            return Ok("Push notification sent successfully!");
        }
    }
}
