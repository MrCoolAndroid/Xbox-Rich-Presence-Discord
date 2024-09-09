using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
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
            navigationStore.CurrentViewModel = new MainScreenViewModel(navigationStore, dialogStore, userStore, deviceStore, mainLogger, themeStore);

            MainWindowViewModel mainWindowViewModel = new(DialogCoordinator.Instance, navigationStore, dialogStore, deviceStore, customDialog, themeStore);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);

            MainWindow = new MainWindow()
            {
                DataContext = mainWindowViewModel
            };
            MainWindow.Show();

            mainLogger.Debug("Starting application...");

            base.OnStartup(e);
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
