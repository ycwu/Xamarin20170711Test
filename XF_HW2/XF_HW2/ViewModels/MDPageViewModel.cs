using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XF_HW2.ViewModels
{
    public class MDPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public DelegateCommand GoMainPageCommand { get; set; }
        public DelegateCommand GoProfileCommand { get; set; }
        public DelegateCommand GoSetupCommand { get; set; }
        public DelegateCommand GoLogoutCommand { get; set; }
        private readonly INavigationService _navigationService;
        public MDPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoMainPageCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/MainPage");
            });

            GoProfileCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/ProfilePage");
            });

            GoSetupCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/SetupPage");
            });

            GoLogoutCommand = new DelegateCommand(async () =>
            {
                if (App.Current.Properties.ContainsKey("IsLogin"))
                    App.Current.Properties["IsLogin"] = false;
                await App.Current.SavePropertiesAsync();
                await _navigationService.NavigateAsync("LoginPage");
            });
        }
    }
}
