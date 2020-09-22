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

        public Image Avatar { get; }

        public ProfileVM(Image avatar)
        {
            Avatar = avatar;
        }
    }
}
