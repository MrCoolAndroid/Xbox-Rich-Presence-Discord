using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Xbox_Discord_Presence.Helpers;
using Xbox_Discord_Presence.Messages;
using Xbox_Discord_Presence.Models;
using Xbox_Discord_Presence.Stores;
using Application = System.Windows.Application;

namespace Xbox_Discord_Presence.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogCoordinator dialogCoordinator;
        private readonly NavigationStore _navigationStore;
        private readonly DialogStore _dialogStore;
        private readonly DeviceStore _deviceStore;
        private readonly CustomDialog _customDialog;
        private readonly ThemeStore _themeStore;
        private readonly SettingsHelper _settingsHelper;

        private bool isSettingsOpen;
        public bool IsSettingsOpen
        {
            get
            {
                return isSettingsOpen;
            }
            set
            {
                isSettingsOpen = value;
                OnPropertyChanged(nameof(IsSettingsOpen));
            }
        }

        private bool useSettings;
        public bool UseSettings
        {
            get
            {
                return useSettings;
            }
            set
            {
                useSettings = value;
                OnPropertyChanged(nameof(UseSettings));
            }
        }

        private bool isQuiet;
        public bool IsQuiet
        {
            get
            {
                return isQuiet;
            }
            set
            {
                isQuiet = value;
                OnPropertyChanged(nameof(IsQuiet));
            }
        }

        private bool offlineLookup;
        public bool OfflineLookup
        {
            get
            {
                return offlineLookup;
            }
            set
            {
                offlineLookup = value;
                OnPropertyChanged(nameof(OfflineLookup));
            }
        }

        private string appStatus;
        public string AppStatus
        {
            get
            {
                return appStatus;
            }
            set
            {
                appStatus = value;
                OnPropertyChanged(nameof(AppStatus));
            }
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(IDialogCoordinator instance, NavigationStore navigationStore, DialogStore dialogStore, DeviceStore deviceStore, CustomDialog customDialog, ThemeStore themeStore, SettingsHelper settingsHelper)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            dialogCoordinator = instance;
            _navigationStore = navigationStore;
            _dialogStore = dialogStore;
            _deviceStore = deviceStore;
            _customDialog = customDialog;
            _themeStore = themeStore;
            _settingsHelper = settingsHelper;
            _navigationStore.ViewChanged += OnViewChanged;
            _dialogStore.DialogCreated += OnDialogCreated;
            _deviceStore.OnRequestDevices += OnRequestedDevices;
            _deviceStore.OnDeviceSelected += OnDeviceSelected;
            _themeStore.ColorChanged += OnColorChanged;
            _settingsHelper.PropertyChanged += OnSettingsChanged;
            PropertyChanged += OnPropertyChangedHandler;

            UseSettings = UserConfiguration.Default.UseSettings;
            IsQuiet = _settingsHelper.Settings.QuietMode;
            OfflineLookup = _settingsHelper.Settings.OfflineLookup;
        }

        private void OnSettingsChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_settingsHelper.AppStatus))
            {
                AppStatus = _settingsHelper.AppStatus;
            }
        }

        private void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UseSettings))
            {
                UserConfiguration.Default.UseSettings = UseSettings;
                UserConfiguration.Default.Save();
                if (!UseSettings)
                {
                    IsQuiet = false;
                    OfflineLookup = false;
                }
            }
            if (e.PropertyName == nameof(IsQuiet) && UseSettings)
            {
                _settingsHelper.Settings.QuietMode = IsQuiet;
                _settingsHelper.WriteSettings();
            }
            if (e.PropertyName == nameof(OfflineLookup) && UseSettings)
            {
                _settingsHelper.Settings.OfflineLookup = OfflineLookup;
                _settingsHelper.WriteSettings();
            }
        }

        [RelayCommand]
        public void OpenSettings()
        {
            if (IsSettingsOpen)
            {
                IsSettingsOpen = false;
            }
            else
            {
                IsSettingsOpen = true;
            }
        }

        private async void OnRequestedDevices()
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                _customDialog.Content = new RequestDeviceDialogViewModel(_deviceStore);
                _customDialog.Title = "Select your device to get presence from";
            });
            await dialogCoordinator.ShowMetroDialogAsync(this, _customDialog);
        }

        private async void OnDialogCreated(Dialog obj)
        {
            if (!_settingsHelper.Settings.QuietMode)
            {
                MessageDialog? dialog = await dialogCoordinator.GetCurrentDialogAsync<MessageDialog>(this);

                if (dialog is not null)
                {
                    if (dialog.Message != obj.Description)
                    {
                        await dialogCoordinator.ShowMessageAsync(this, obj.Title, obj.Description);
                    }
                }
                else
                {
                    await dialogCoordinator.ShowMessageAsync(this, obj.Title, obj.Description);
                }
            }
        }

        private void OnViewChanged(ViewModelBase obj)
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private async void OnDeviceSelected(string obj)
        {
            CustomDialog currentDialog = await dialogCoordinator.GetCurrentDialogAsync<CustomDialog>(this);
            await dialogCoordinator.HideMetroDialogAsync(this, currentDialog);
        }

        private void OnColorChanged(string colorHEX)
        {
            if (colorHEX != null && colorHEX != "null")
            {
                colorHEX = "#" + colorHEX;

                Color primaryAccent = (Color)ColorConverter.ConvertFromString(colorHEX);
                Brush showcaseBrush = (Brush)new BrushConverter().ConvertFrom(colorHEX);

                Application.Current.Dispatcher.Invoke(delegate
                {
                    Theme newTheme = new("CustomUserTheme", "Custom User Theme", "Dark", "Red", primaryAccent, showcaseBrush, true, false);

                    ThemeManager.Current.ChangeTheme(Application.Current, newTheme);
                });
            }
            else
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Blue");
                });
            }
        }
    }
}
