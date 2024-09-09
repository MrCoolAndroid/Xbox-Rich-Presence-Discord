using CommunityToolkit.Mvvm.ComponentModel;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Xbox_Discord_Presence.Messages;
using Xbox_Discord_Presence.Models;
using Xbox_Discord_Presence.Stores;
using Application = System.Windows.Application;

namespace Xbox_Discord_Presence.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogCoordinator dialogCoordinator;
        private readonly NavigationStore _navigationStore;
        private readonly DialogStore _dialogStore;
        private readonly DeviceStore _deviceStore;
        private readonly CustomDialog _customDialog;
        private readonly ThemeStore _themeStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(IDialogCoordinator instance, NavigationStore navigationStore, DialogStore dialogStore, DeviceStore deviceStore, CustomDialog customDialog, ThemeStore themeStore)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            dialogCoordinator = instance;
            _navigationStore = navigationStore;
            _dialogStore = dialogStore;
            _deviceStore = deviceStore;
            _customDialog = customDialog;
            _themeStore = themeStore;
            _navigationStore.ViewChanged += OnViewChanged;
            _dialogStore.DialogCreated += OnDialogCreated;
            _deviceStore.OnRequestDevices += OnRequestedDevices;
            _deviceStore.OnDeviceSelected += OnDeviceSelected;
            _themeStore.ColorChanged += OnColorChanged;
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
            await dialogCoordinator.ShowMessageAsync(this, obj.Title, obj.Description);
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
