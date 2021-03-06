﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XF_HW2.ViewModels
{
    public class ThemePageViewModel : INotifyPropertyChanged, INavigationAware
    { 
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }

        public DelegateCommand GoHomeCommand { get; set; }

        private readonly INavigationService _navigationService;
        public ThemePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoHomeCommand = new DelegateCommand(async() => 
            {
                //await _navigationService.NavigateAsync("MainPage");
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/MainPage?title=Hello%20from%20Xamarin.Forms");
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
