using FolderApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolderApp.Services
{
    public interface IDeviceInstallationService
    {
        string Token { get; set; }
        bool NotificationsSupported { get; }
        string GetDeviceId();
        DeviceInstallation GetDeviceInstallation(params string[] tags);
    }
}
