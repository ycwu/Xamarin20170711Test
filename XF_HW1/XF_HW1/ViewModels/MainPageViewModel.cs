using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace XF_HW1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public string Entry { get; set; } = "";

        public DelegateCommand LoginCommand { get; set; }

        #region 用來偵測 YourAccount 是否已經有變動
        // https://github.com/Fody/PropertyChanged/wiki/On_PropertyName_Changed
        void OnEntryChanged()
        {
            // 當YourAccount 的內容有變動的時候，需要更新指定的 DelegateCommand 物件，
            // 是否可以啟用
            LoginCommand.RaiseCanExecuteChanged();
        }
        #endregion

        public MainPageViewModel()
        {
            LoginCommand = new DelegateCommand(
            () =>
            {
                Title = Entry;
            },
            () =>
            {
                if (IsValidEmail(Entry))
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            //if (parameters.ContainsKey("title"))
                //Title = (string)parameters["title"] + " and Prism";
        }

        public bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn)) return false;
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
