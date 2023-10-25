using WebAPi6.Models;

namespace WebAPi6.Middleware.NotificationService
{
    public interface INotificationService
    {
        public Task<NotificationResponse> SendNotification(Notification notification);
    }
}
