using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XF_HW2.ViewModels
{
    public class FavoritePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public DelegateCommand GoThemeCommand { get; set; }

        private readonly INavigationService _navigationService;
        public FavoritePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoThemeCommand = new DelegateCommand(async () =>
              {
                  await _navigationService.NavigateAsync("ThemePage");
              });

        }
    }
}
