using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XF_HW2.ViewModels
{
    public class SetupPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }

        public DelegateCommand GoFavoriteCommand { get; set; }

        private readonly INavigationService _navigationService;

        public SetupPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoFavoriteCommand = new DelegateCommand(async() => 
            {
                await _navigationService.NavigateAsync("FavoritePage");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
