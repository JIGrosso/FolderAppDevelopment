using System;


namespace FolderApp.Services
{
    public interface IPushNotificationActionService : INotificationActionService
    {
        event EventHandler<PushDemoAction> ActionTriggered;
    }
}
