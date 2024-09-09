using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Xbox_Discord_Presence.Messages;
using Xbox_Discord_Presence.Models;
using MahApps.Metro.Controls.Dialogs;
using Xbox_Discord_Presence.Views;
using Xbox_Discord_Presence.Stores;

namespace Xbox_Discord_Presence.ViewModels
{
    public class MainScreenViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly DialogStore _dialogStore;
        private readonly UserStore _userStore;
        private readonly DeviceStore _deviceStore;
        private readonly Logger _logger;
        private readonly ThemeStore _themeStore;

        private string? gamertag;
        public string? Gamertag
        {
            get
            {
                return gamertag;
            }
            set
            {
                gamertag = value;
                OnPropertyChanged(nameof(Gamertag));
            }
        }

        private string? apiKey;
        public string? APIKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
                OnPropertyChanged(nameof(APIKey));
            }
        }

        private bool isLimitedTo150;
        public bool IsLimitedTo150
        {
            get
            {
                return isLimitedTo150;
            }
            set
            {
                isLimitedTo150 = value;
                OnPropertyChanged(nameof(IsLimitedTo150));
            }
        }

        private bool isUsingSteamGridDB;
        public bool IsUsingSteamGridDB
        {
            get
            {
                return isUsingSteamGridDB;
            }
            set
            {
                isUsingSteamGridDB = value;
                OnPropertyChanged(nameof(IsUsingSteamGridDB));
            }
        }

        private bool isUsingImagesAPI;
        public bool IsUsingImagesAPI
        {
            get
            {
                return isUsingImagesAPI;
            }
            set
            {
                isUsingImagesAPI = value;
                OnPropertyChanged(nameof(IsUsingImagesAPI));
            }
        }

        private Visibility loadingAnimation = Visibility.Hidden;
        public Visibility LoadingAnimation
        {
            get
            {
                return loadingAnimation;
            }
            set
            {
                loadingAnimation = value;
                OnPropertyChanged(nameof(LoadingAnimation));
            }
        }

        private List<string> availableLanguages = new();
        public List<string> AvailableLanguages
        {
            get
            {
                return availableLanguages;
            }
            set
            {
                availableLanguages = value;
                OnPropertyChanged(nameof(AvailableLanguages));
            }
        }

        private string selectedLanguage;
        public string SelectedLanguage
        {
            get
            {
                return selectedLanguage;
            }
            set
            {
                selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }

        private bool canModify = true;
        public bool CanModify
        {
            get
            {
                return canModify;
            }
            set
            {
                canModify = value;
                OnPropertyChanged(nameof(CanModify));
            }
        }

        public RelayCommand StartCommand { get; set; }
        public RelayCommand OnTextChanged { get; set; }
        private bool IsLoading { get; set; }

        public MainScreenViewModel(NavigationStore navigationStore, DialogStore dialogStore, UserStore userStore, DeviceStore deviceStore, Logger logger, ThemeStore themeStore)
        {
            _navigationStore = navigationStore;
            _dialogStore = dialogStore;
            _userStore = userStore;
            _deviceStore = deviceStore;
            _logger = logger;
            _themeStore = themeStore;
            Gamertag = UserConfiguration.Default.Gamertag;
            APIKey = UserConfiguration.Default.API;
            AvailableLanguages.Add("Spanish");
            AvailableLanguages.Add("English");
            StartCommand = new RelayCommand(BeginProcess, CanExecuteStart);
            OnTextChanged = new RelayCommand(TextChanged);
            _themeStore.ChangeColor("null");
        }

        private void TextChanged()
        {
            StartCommand.NotifyCanExecuteChanged();
        }

        private bool CanExecuteStart()
        {
            return Gamertag is not null and not "" && APIKey is not null and not "" && !IsLoading;
        }

        private async void BeginProcess()
        {
            LoadingAnimation = Visibility.Visible;
            IsLoading = true;
            CanModify = false;
            StartCommand.NotifyCanExecuteChanged();
            InitialClass initialClass = new();
            initialClass.APIKey = APIKey;
            initialClass.Gamertag = Gamertag;
            initialClass.IsLimitedTo150 = IsLimitedTo150;
            initialClass.IsUsingSteamGridDB = IsUsingSteamGridDB;
            initialClass.Language = SelectedLanguage;
            initialClass.IsUsingImagesAPI = IsUsingImagesAPI;
            await Task.Delay(1500);
            UserConfiguration.Default.Gamertag = Gamertag;
            UserConfiguration.Default.API = APIKey;
            UserConfiguration.Default.Save();
            _userStore.User = initialClass;
            _navigationStore.CurrentViewModel = new PresenceViewModel(_navigationStore, _dialogStore, _userStore, _deviceStore, _logger, _themeStore);
            CanModify = true;
            StartCommand.NotifyCanExecuteChanged();
        }
    }
}
