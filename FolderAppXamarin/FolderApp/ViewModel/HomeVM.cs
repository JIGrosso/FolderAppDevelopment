using FolderApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    class HomeVM : INotifyPropertyChanged
    {
        public ObservableCollection<Activity> Activities { get; set; } = new ObservableCollection<Activity>();

        public int CurrentPage { get; set; } = 0;

        private bool isRefreshing = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        public bool ScrolledDown = true;

        private Activity selectedItem { get; set; }
        public Activity SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public ICommand ItemTapped
        {
            get
            {
                return new Command(_ =>
                {
                    if (SelectedItem == null)
                        return;
                    SelectedItem = null;
                    /*

                    Expand(SelectedItem);
                    
                    */
                    return;
                });
            }
        }

        public ICommand LoadMoreActivitiesCommand
        {
            get
            {
                return new Command(_ =>
                {
                    if (!IsRefreshing)
                        Task.Run(() => GetActivities(page: CurrentPage + 1));
                });
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(_ =>
                {
                    if (!ScrolledDown)
                    {
                        Task.Run(() => GetActivities(page: 1, isRefresh: true));
                    }
                });
            }
        }

        public async Task GetActivities(int page = 1, bool isRefresh = false)
        {
            if (page <= CurrentPage)
            {
                return;
            }

            IsRefreshing = true;

            if (isRefresh)
            {
                ScrolledDown = false;

            }

            CurrentPage = page;

            ObservableCollection<Activity> activities;

            activities = await Activity.GetActivities(page: CurrentPage, existent: App.AppCache.Activities.Keys.ToArray());

            foreach (var x in activities)
            {
                Activities.Add(x);
            }

            IsRefreshing = false;

        }

        public HomeVM()
        {
            foreach(Activity aux in App.AppCache.Activities.Values.OrderByDescending(x => x.Date))
            {
                Activities.Add(aux);
            }

        }
    }
}
