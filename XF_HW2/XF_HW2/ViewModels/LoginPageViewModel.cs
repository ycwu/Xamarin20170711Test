using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XF_HW2.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }

        public DelegateCommand GoMainCommand { get; set; }

        private readonly INavigationService _navigationService;
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoMainCommand = new DelegateCommand(async() => 
            {
                if (App.Current.Properties.ContainsKey("IsLogin"))
                    App.Current.Properties["IsLogin"] = true;
                await App.Current.SavePropertiesAsync();
                await _navigationService.NavigateAsync("MDPage/NaviPage/MainPage?title=Hello%20from%20Xamarin.Forms");
            });
            //App.Current.MainPage = your new mailpage
            //App.Current.Properties["CurrMainPage"] = "P1";
            //App.Current.SavePropertiesAsync();
        }
    }
}
