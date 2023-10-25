using Microsoft.AspNetCore.Mvc;
using WebAPi6.Middleware.NotificationService;
using WebAPi6.Models;

namespace WebAPi6.Controllers
{
    [ApiController]
    [Route("notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendNotification(Notification notification)
        {
            var result = await _notificationService.SendNotification(notification);
            return Ok(result);
        }
    }
}
