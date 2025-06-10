using log4net.Config;
using log4net.Repository.Hierarchy;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Models;
using Xbox_Discord_Presence.Stores;
using log4net.Repository;
using Logger = Xbox_Discord_Presence.Models.Logger;
using System.ComponentModel;

namespace Xbox_Discord_Presence.Helpers
{
    public class SettingsHelper : INotifyPropertyChanged
    {
        private readonly DialogStore _dialogStore;

        private Settings settings;
        public Settings Settings
        {
            get
            {
                return settings;
            }
            private set
            {
                settings = value;
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

        public event Action StartupRequested;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly ILoggerRepository logRepository;
        private readonly Logger mainLogger;

        public SettingsHelper(DialogStore dialogStore, Logger logger)
        {
            _dialogStore = dialogStore;
            Settings = new Settings();

            logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));
            mainLogger = logger;

            ReadSettings();
        }

        public void RequestStartup()
        {
            StartupRequested?.Invoke();
        }

        private void ReadSettings()
        {
            try
            {
                using StreamReader r = new("settings.json");
                string json = r.ReadToEnd();
                Settings = JsonConvert.DeserializeObject<Settings>(json);

                if (Settings is null)
                {
                    PopulateSettings();
                }
            }
            catch (FileNotFoundException)
            {
                PopulateSettings();
            }
        }

        public void WriteSettings()
        {
            string json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            using StreamWriter outputFile = new("settings.json");
            outputFile.WriteLine(json);
        }

        private async void PopulateSettings()
        {
            try
            {
                using StreamWriter outputFile = new("settings.json");
                Settings defaultSettings = new()
                {
                    Gamertag = "",
                    OXBLAPI = "",
                    OfflineLookup = false,
                    RateLimit = false,
                    Language = "English",
                    Device = "",
                    IconMethod = 0,
                    SGDBAPI = "",
                    QuietMode = false,
                };
                string json = JsonConvert.SerializeObject(defaultSettings, Formatting.Indented);
                outputFile.WriteLine(json);
            }
            catch (IOException e)
            {
                mainLogger.Fatal("An error occurred while creating the settings file: " + e.Message);
                Dialog dialog = new()
                {
                    Title = "Could not create settings file",
                    Description = "An error occurred while creating or modifying the settings file. Please check your permissions and make sure the file is not occupied."
                };
                await Task.Delay(1000);
                _dialogStore.ShowDialog(dialog);
            }
            catch (UnauthorizedAccessException e)
            {
                mainLogger.Fatal("You do not have permission to create the settings file: " + e.Message);
                Dialog dialog = new()
                {
                    Title = "Could not create settings file",
                    Description = "An error occurred while creating or modifying the settings file. Please check your permissions and make sure the file is not occupied."
                };
                await Task.Delay(1000);
                _dialogStore.ShowDialog(dialog);
            }
            catch (Exception e)
            {
                mainLogger.Fatal("An unexpected error occurred: " + e.Message);
                Dialog dialog = new()
                {
                    Title = "Could not create settings file",
                    Description = "An error occurred while creating or modifying the settings file. Please check your permissions and make sure the file is not occupied."
                };
                await Task.Delay(1000);
                _dialogStore.ShowDialog(dialog);
            }
        }
    }
}
