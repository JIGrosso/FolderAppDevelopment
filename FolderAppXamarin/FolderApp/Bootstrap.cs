using FolderApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolderApp
{
    public static class Bootstrap
    {
        public static void Begin(Func<IDeviceInstallationService> deviceInstallationService)
        {
            ServiceContainer.Register(deviceInstallationService);

            ServiceContainer.Register<IPushNotificationActionService>(()
                => new PushNotificationActionService());

            ServiceContainer.Register<INotificationRegistrationService>(()
                => new NotificationRegistrationService(
                    Config.BackendServiceEndpoint,
                    Config.ApiKey));
        }
    }
}
