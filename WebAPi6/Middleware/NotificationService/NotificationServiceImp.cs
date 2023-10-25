using CorePush.Google;
using WebAPi6.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using static WebAPi6.Models.GoogleNotification;
using Microsoft.Extensions.Options;

namespace WebAPi6.Middleware.NotificationService
{
    public class NotificationServiceImp : INotificationService
    {
        private readonly FcmNotificationSetting _fcmNotificationSetting;
        public NotificationServiceImp(IOptions<FcmNotificationSetting> fcmNotificationSetting)
        {
            _fcmNotificationSetting = fcmNotificationSetting.Value;
        }
        public async Task<NotificationResponse> SendNotification(Notification notificationModel)
        {
            NotificationResponse response = new NotificationResponse();
            try
            {
                FcmSettings fcmSettings = new FcmSettings()
                {
                    SenderId = _fcmNotificationSetting.SenderId,
                    ServerKey = _fcmNotificationSetting.ServerKey,
                };

                HttpClient httpClient = new HttpClient();
                string authorizationKey = string.Format("key={0}", fcmSettings.ServerKey);
                string deviceToken = notificationModel.DeviceId;
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataPayload dataPayload = new DataPayload();
                dataPayload.Title = notificationModel.Title;
                dataPayload.Message = notificationModel.Message;
                dataPayload.CartDetails = notificationModel.CartDetails;

                GoogleNotification googleNotification = new GoogleNotification();
                googleNotification.Data = dataPayload;
                googleNotification.Notification = dataPayload;

                var fcm = new FcmSender(fcmSettings, httpClient);

                var fcmSendResponse = await fcm.SendAsync(deviceToken, googleNotification);

                if(fcmSendResponse.IsSuccess())
                {
                    response.IsSuccess = true;
                    response.Message = "Notification sent successfully";
                    response.CartDetails = notificationModel.CartDetails;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = fcmSendResponse.Results[0].Error;
                    return response;
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
