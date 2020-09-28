using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    class ProfileVM
    {
        public string Name
        {
            get
            {
                return App.User.CompleteName;
            }
        }

        public string Email
        {
            get
            {
                return App.User.Email;
            }
        }

        public string Birthday
        {
            get
            {
                return App.User.Birthday;
            }
        }

        public List<KeyValuePair<string, string>> Fields { get; set; } = new List<KeyValuePair<string, string>>();

        public Image Avatar { get; }

        public ProfileVM(Image avatar)
        {
            Avatar = avatar;
            Fields.Add(new KeyValuePair<string, string>("Fecha de Ingreso", App.User.FechaIngreso));
            Fields.Add(new KeyValuePair<string, string>("Skype ID", App.User.SkypeId));
            Fields.Add(new KeyValuePair<string, string>("Celular", App.User.Celular));
        }
    }
}
