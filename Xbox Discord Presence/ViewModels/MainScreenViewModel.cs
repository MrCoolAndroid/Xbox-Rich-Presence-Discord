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
using Xbox_Discord_Presence.Helpers;
using System.IO;

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
        private readonly SettingsHelper _settingsHelper;

        private string gamertag;
        public string Gamertag
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

        private string apiKey;
        public string APIKey
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

        private string additionalapiKey;
        public string additionalAPIKey
        {
            get => additionalapiKey;
            set
            {
                if (additionalapiKey != value)
                {
                    additionalapiKey = value;
                    if (_userStore?.User != null)
                        _userStore.User.additionalAPIKey = value;
                    OnPropertyChanged();
                }
            }
        }


        private bool isLimitedTo150;
        public bool IsLimitedTo150
        {
            get => isLimitedTo150;
            set
            {
                if (isLimitedTo150 != value)
                {
                    isLimitedTo150 = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool startOnStartup;
        public bool StartOnStartup
        {
            get => startOnStartup;
            set
            {
                if (startOnStartup != value)
                {
                    startOnStartup = value;
                    OnPropertyChanged();
                    if (startOnStartup)
                        Xbox_Discord_Presence.Helpers.StartupHelper.AddAppToStartup();
                    else
                        Xbox_Discord_Presence.Helpers.StartupHelper.RemoveAppFromStartup();
                }
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
        public RelayCommand OpenAdditionalOptionsCommand { get; set; }
        private bool IsLoading { get; set; }

        public MainScreenViewModel(NavigationStore navigationStore, DialogStore dialogStore, UserStore userStore, DeviceStore deviceStore, Logger logger, ThemeStore themeStore, SettingsHelper settingsHelper)
        {
            _navigationStore = navigationStore;
            _dialogStore = dialogStore;
            _userStore = userStore;
            _deviceStore = deviceStore;
            _logger = logger;
            _themeStore = themeStore;
            _settingsHelper = settingsHelper;
            Gamertag = UserConfiguration.Default.Gamertag;
            APIKey = UserConfiguration.Default.API;
            AvailableLanguages.Add("Spanish");
            AvailableLanguages.Add("English");
            SelectedLanguage = "English";
            if (UserConfiguration.Default.UseSettings)
            {
                Gamertag = _settingsHelper.Settings.Gamertag;
                APIKey = _settingsHelper.Settings.OXBLAPI;
                SelectedLanguage = _settingsHelper.Settings.Language ?? "English";
                IsLimitedTo150 = _settingsHelper.Settings.RateLimit;
                IsUsingSteamGridDB = _settingsHelper.Settings.IconMethod == 0;
                IsUsingImagesAPI = _settingsHelper.Settings.IconMethod == 1;
            }
            StartCommand = new RelayCommand(BeginProcess, CanExecuteStart);
            OnTextChanged = new RelayCommand(TextChanged);
            OpenAdditionalOptionsCommand = new RelayCommand(OpenAdditionalOptions);
            _themeStore.ChangeColor("null");
            _settingsHelper.StartupRequested += OnStartupRequested;
        }

        private void OpenAdditionalOptions()
        {
            if (_userStore?.User != null)
            {
                IsLimitedTo150 = _userStore.User.IsLimitedTo150;
            }
            var window = new Xbox_Discord_Presence.Views.AdditionalOptionsWindow(this);
            window.ShowDialog();
        }

        private void OnStartupRequested()
        {
            BeginProcess();
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
            InitialClass initialClass = new()
            {
                APIKey = APIKey,
                Gamertag = Gamertag,
                IsLimitedTo150 = IsLimitedTo150,
                IsUsingSteamGridDB = IsUsingSteamGridDB,
                Language = SelectedLanguage,
                additionalAPIKey = additionalAPIKey,
                IsUsingImagesAPI = IsUsingImagesAPI
            };
            await Task.Delay(1500);
            UserConfiguration.Default.Gamertag = Gamertag;
            UserConfiguration.Default.API = APIKey;
            UserConfiguration.Default.Save();
            if (UserConfiguration.Default.UseSettings)
            {
                _settingsHelper.Settings.Gamertag = Gamertag;
                _settingsHelper.Settings.OXBLAPI = APIKey;
                _settingsHelper.Settings.RateLimit = IsLimitedTo150;
                _settingsHelper.Settings.Language = SelectedLanguage;
                initialClass.SteamGridDBKey = _settingsHelper.Settings.SGDBAPI;
                if (IsUsingSteamGridDB)
                {
                    _settingsHelper.Settings.IconMethod = 0;
                }
                else if (IsUsingImagesAPI)
                {
                    _settingsHelper.Settings.IconMethod = 1;
                }
                else
                {
                    _settingsHelper.Settings.IconMethod = 2;
                }
                _settingsHelper.WriteSettings();
            }
            _userStore.User = initialClass;
            _navigationStore.CurrentViewModel = new PresenceViewModel(_navigationStore, _dialogStore, _userStore, _deviceStore, _logger, _themeStore, _settingsHelper);
            CanModify = true;
            StartCommand.NotifyCanExecuteChanged();
        }
    }
}
