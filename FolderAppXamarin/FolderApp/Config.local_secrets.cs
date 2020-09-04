using System;
using System.Collections.Generic;
using System.Text;

namespace FolderApp
{
    public static partial class Config
    {
        static Config()
        {
            ApiKey = "<your_api_key>";
            BackendServiceEndpoint = "<your_api_app_url>";
        }
    }
}
