using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Xbox_Discord_Presence.Helpers;
using Xbox_Discord_Presence.Models;
using Xbox_Discord_Presence.Stores;
using Xbox_Discord_Presence.ViewModels;
using Application = System.Windows.Application;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Logger = Xbox_Discord_Presence.Models.Logger;

namespace Xbox_Discord_Presence
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Logger mainLogger = new();
        protected override void OnStartup(StartupEventArgs e)
        {
            DeviceStore deviceStore = new()
            {
                Devices = new()
            };
            ThemeStore themeStore = new();
            NavigationStore navigationStore = new();
            DialogStore dialogStore = new();
            UserStore userStore = new();
            CustomDialog customDialog = new();
            SettingsHelper settingsHelper = new(dialogStore, mainLogger);
            navigationStore.CurrentViewModel = new MainScreenViewModel(navigationStore, dialogStore, userStore, deviceStore, mainLogger, themeStore, settingsHelper);

            MainWindowViewModel mainWindowViewModel = new(DialogCoordinator.Instance, navigationStore, dialogStore, deviceStore, customDialog, themeStore, settingsHelper);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);

            MainWindow = new MainWindow()
            {
                DataContext = mainWindowViewModel
            };

            mainLogger.Debug("Starting application...");

            base.OnStartup(e);

            try
            {
                if (!UserConfiguration.Default.UseSettings)
                {
                    MainWindow.Show();
                }
                else
                {
                    if (!settingsHelper.Settings.QuietMode)
                    {
                        MainWindow.Show();
                    }
                    else
                    {
                        if (settingsHelper.Settings.Gamertag is null or "" && settingsHelper.Settings.OXBLAPI is null or "" && settingsHelper.Settings.Device is null or "")
                        {
                            MainWindow.Show();
                            mainLogger.Fatal("Gamertag, OXBLAPI or Device is not set. Please set them in settings.json.");
                            Dialog dialog = new()
                            {
                                Title = "Could not start quiet mode",
                                Description = "Gamertag, OXBLAPI or Device is not set. Please set them in settings.json."
                            };
                            dialogStore.ShowDialog(dialog);
                        }
                        else
                        {
                            settingsHelper.RequestStartup();
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MainWindow.Show();
            }
        }

        private string GenerateRgba(string backgroundColor, decimal backgroundOpacity)
        {
            Color color = (Color)ColorConverter.ConvertFromString(backgroundColor);
            int r = Convert.ToInt16(color.R);
            int g = Convert.ToInt16(color.G);
            int b = Convert.ToInt16(color.B);
            return string.Format("rgba({0}, {1}, {2}, {3});", r, g, b, backgroundOpacity);
        }

        private void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                mainLogger.Fatal("Unhandled exception occurred! ", ex);
            }
            else
            {
                mainLogger.Fatal("Unhandled non-exception object occurred! " + e.ExceptionObject.ToString());
            }
        }
    }
}
