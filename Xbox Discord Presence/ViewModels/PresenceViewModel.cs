using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xbox_Discord_Presence.Messages;
using Xbox_Discord_Presence.Models;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading;
using System.Windows.Media.Imaging;
using DiscordRPC;
using MahApps.Metro.Controls.Dialogs;
using System.Runtime.InteropServices;
using Xbox_Discord_Presence.Views;
using CommunityToolkit.Mvvm.Input;
using Xbox_Discord_Presence.Stores;
using DiscordRPC.Message;
using System.Collections.ObjectModel;
using System.Windows;
using craftersmine.SteamGridDBNet;
using Application = System.Windows.Application;
using System.Reflection;
using log4net;
using log4net.Config;
using log4net.Repository;
using ControlzEx.Standard;
using Xbox_Discord_Presence.Helpers;

namespace Xbox_Discord_Presence.ViewModels
{
    public class PresenceViewModel : ViewModelBase
    {
        public DiscordRpcClient Client { get; private set; }
        private readonly SteamGridDb sgdb;
        private readonly NavigationStore _navigationStore;
        private readonly DialogStore _dialogStore;
        private readonly UserStore _userStore;
        private readonly DeviceStore _deviceStore;
        private readonly ThemeStore _themeStore;
        private readonly SettingsHelper _settingsHelper;
        private bool isRunning;

        private string gamertag;
        public string Gamertag
        {
            get => gamertag;
            set
            {
                gamertag = value;
                OnPropertyChanged(nameof(Gamertag));
            }
        }

        private string status;
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string gameTitle;
        public string GameTitle
        {
            get => gameTitle;
            set
            {
                gameTitle = value;
                OnPropertyChanged(nameof(GameTitle));
            }
        }

        private string deviceName;
        public string DeviceName
        {
            get => deviceName;
            set
            {
                deviceName = value;
                OnPropertyChanged(nameof(DeviceName));
            }
        }

        private string richPresence;
        public string RichPresence
        {
            get => richPresence;
            set
            {
                richPresence = value;
                OnPropertyChanged(nameof(RichPresence));
            }
        }

        private string appStatus;
        public string AppStatus
        {
            get => appStatus;
            set
            {
                appStatus = value;
                OnPropertyChanged(nameof(AppStatus));
            }
        }

        private ImageSource gamerpic;
        public ImageSource Gamerpic
        {
            get => gamerpic;
            set
            {
                gamerpic = value;
                OnPropertyChanged(nameof(Gamerpic));
            }
        }

        private ImageSource gamePicture;
        public ImageSource GamePicture
        {
            get => gamePicture;
            set
            {
                gamePicture = value;
                OnPropertyChanged(nameof(GamePicture));
            }
        }

        private ImageSource gameBackground;
        public ImageSource GameBackground
        {
            get => gameBackground;
            set
            {
                gameBackground = value;
                OnPropertyChanged(nameof(GameBackground));
            }
        }

        private bool isLoadingGamePicture;
        public bool IsLoadingGamePicture
        {
            get => isLoadingGamePicture;
            set
            {
                isLoadingGamePicture = value;
                OnPropertyChanged(nameof(IsLoadingGamePicture));
            }
        }

        private bool isLoadingGamerpic;
        public bool IsLoadingGamerpic
        {
            get => isLoadingGamerpic;
            set
            {
                isLoadingGamerpic = value;
                OnPropertyChanged(nameof(IsLoadingGamerpic));
            }
        }

        private Visibility isUsingSteamGridDB = Visibility.Hidden;
        public Visibility IsUsingSteamGridDB
        {
            get => isUsingSteamGridDB;
            set
            {
                isUsingSteamGridDB = value;
                OnPropertyChanged(nameof(IsUsingSteamGridDB));
            }
        }

        private Visibility isLimitingTo150 = Visibility.Hidden;
        public Visibility IsLimitingTo150
        {
            get => isLimitingTo150;
            set
            {
                isLimitingTo150 = value;
                OnPropertyChanged(nameof(IsLimitingTo150));
            }
        }

        private string apiKey;
        public string APIKey
        {
            get => apiKey;
            set
            {
                apiKey = value;
                OnPropertyChanged(nameof(APIKey));
            }
        }

        private SearchAccount xboxAccountsList;
        public SearchAccount XboxAccountsList
        {
            get => xboxAccountsList;
            set
            {
                xboxAccountsList = value;
                OnPropertyChanged(nameof(XboxAccountsList));
            }
        }

        private Presence xboxPresence;
        public Presence XboxPresence
        {
            get => xboxPresence;
            set
            {
                xboxPresence = value;
                OnPropertyChanged(nameof(XboxPresence));
            }
        }

        private InitialClass startClass;
        public InitialClass StartClass
        {
            get => startClass;
            set
            {
                startClass = value;
                OnPropertyChanged(nameof(StartClass));
            }
        }

        private string selectedDevice;
        public string SelectedDevice
        {
            get => selectedDevice;
            set
            {
                selectedDevice = value;
                OnPropertyChanged(nameof(SelectedDevice));
            }
        }

        public RelayCommand GoBack { get; set; }
        public RelayCommand OnSelectDevice { get; set; }
        private bool IsDisposing;

        private readonly ILoggerRepository logRepository;
        private readonly Logger mainLogger;

        public PresenceViewModel(NavigationStore navigationStore, DialogStore dialogStore, UserStore userStore, DeviceStore deviceStore, Logger logger, ThemeStore themeStore, SettingsHelper settingsHelper)
        {
            isRunning = false;
            GoBack = new RelayCommand(GoBackToMain);
            _navigationStore = navigationStore;
            _dialogStore = dialogStore;
            _userStore = userStore;
            _deviceStore = deviceStore;
            _themeStore = themeStore;
            _settingsHelper = settingsHelper;
            _navigationStore.ViewChanged += OnViewChanged;
            _deviceStore.OnDeviceSelected += LoadDevice;
            PropertyChanged += OnPropertyChangedHandler;

            if (_settingsHelper.Settings.SGDBAPI == "" || _settingsHelper.Settings.SGDBAPI is null)
            {
                sgdb = new("9c0bdf65434ebaedbc53a444a3194c0c");
            }
            else
            {
                sgdb = new(_settingsHelper.Settings.SGDBAPI);
            }

            logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));
            mainLogger = logger;
        }

        private void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AppStatus))
            {
                _settingsHelper.AppStatus = AppStatus;
            }
        }

        private void GoBackToMain()
        {
            AppStatus = "In Main screen...";
            _navigationStore.CurrentViewModel = new MainScreenViewModel(_navigationStore, _dialogStore, _userStore, _deviceStore, mainLogger, _themeStore, _settingsHelper);
        }

        private void OnViewChanged(ViewModelBase obj)
        {
            if (obj == this)
            {
                StartProcess();
                IsDisposing = false;
            }
        }

        public async void StartProcess()
        {
            if (!IsDisposing)
            {
                mainLogger.Debug("IsLimitedWorking?? " + _userStore.User.IsLimitedTo150.ToString());
                await Task.Delay(1000);
                AppStatus = "Connecting to Discord...";
                mainLogger.Debug("Connecting to Discord...");
                Client = new DiscordRpcClient("936699316960120953");
                Client.Initialize();
                Client.OnReady += OnDiscordConnectionReady;
                Client.OnConnectionFailed += OnDiscordConnectionFailed;
            }
        }

        private void OnDiscordConnectionReady(object sender, ReadyMessage args)
        {
            if (!IsDisposing)
            {
                mainLogger.Debug("Connected to Discord");
                AppStatus = "Connected!";
                if (!isRunning)
                {
                    IsLoadingGamerpic = true;
                    IsLoadingGamePicture = true;
                    IsLimitingTo150 = _userStore.User.IsLimitedTo150 ? Visibility.Visible : Visibility.Hidden;
                    IsUsingSteamGridDB = _userStore.User.IsUsingSteamGridDB ? Visibility.Visible : Visibility.Hidden;
                    LoadData(_userStore.User);
                }
            }
        }

        private async void OnDiscordConnectionFailed(object sender, ConnectionFailedMessage args)
        {
            Debug.WriteLine("Couldn't connect to Discord, trying again...");
            AppStatus = "Couldn't connect, trying again...";
            mainLogger.Debug("Could not connect, trying again in 2.5 seconds");
            await Task.Delay(2500);
            AppStatus = "Connecting to Discord...";
        }

        private async void LoadData(InitialClass message)
        {
            if (!IsDisposing)
            {
                if (_userStore.User.Language is null || _userStore.User.Language == "")
                {
                    _userStore.User.Language = "English";
                    mainLogger.Debug("No language selected for the Rich Presence, using English by default");
                }
                while (Status != "Online" && !IsDisposing)
                {
                    Gamertag = message.Gamertag;
                    APIKey = message.APIKey;
                    AppStatus = "Searching your Xbox account...";
                    mainLogger.Debug("Searching Xbox Account...");
                    XboxAccountsList = await SearchXboxAccountAsync();
                    if (XboxAccountsList.ProfileUsers is null)
                    {
                        break;
                    }
                    if (XboxAccountsList.ProfileUsers.Count <= 0)
                    {
                        Dialog dialog = new()
                        {
                            Title = "Error!",
                            Description = "The Gamertag was not found! Check for any typos"
                        };
                        AppStatus = "Go back and try again";
                        _dialogStore.ShowDialog(dialog);
                        mainLogger.Debug("The Xbox account was not found (Account list from searching returned 0 values)");
                        break;
                    }
                    else
                    {
                        AppStatus = "Using " + XboxAccountsList.ProfileUsers[0].Settings[2].Value + " account";
                        mainLogger.Debug("Using " + XboxAccountsList.ProfileUsers[0].Settings[2].Value + " account (The first account on the list)");
                        XboxPresence = await GetPresenceAsync(XboxAccountsList);
                        Status = XboxPresence.State;
                        AppStatus = "Done getting presence!";

                        string userColors = XboxAccountsList.ProfileUsers[0].Settings[5].Value;
                        if (userColors != null)
                        {
                            using HttpClient client = new();

                            string result = await client.GetStringAsync(userColors);
                            UserColor userColor = JsonConvert.DeserializeObject<UserColor>(result);

                            _themeStore.ChangeColor(userColor.primaryColor);
                        }

                        if (Status == "Offline")
                        {
                            if (!_settingsHelper.Settings.OfflineLookup)
                            {
                                AppStatus = "User is offline, trying again...";
                                mainLogger.Debug("User is offline, trying again...");
                            }
                            else
                            {
                                Dialog dialog = new()
                                {
                                    Title = "Error!",
                                    Description = "The user is offline! Go back and try again"
                                };
                                _dialogStore.ShowDialog(dialog);
                                AppStatus = "User offline, go back and try again";
                                break;
                            }
                            if (_userStore.User.IsLimitedTo150)
                            {
                                await Task.Delay(30000);
                            }
                            else
                            {
                                await Task.Delay(10000);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (XboxAccountsList.ProfileUsers is not null && XboxAccountsList.ProfileUsers.Count >= 1 && !IsDisposing)
                {
                    AppStatus = "Getting gamerpic...";

                    Application.Current.Dispatcher.Invoke(delegate
                    {
                        BitmapImage src = new();
                        src.BeginInit();
                        src.UriSource = new System.Uri(XboxAccountsList.ProfileUsers[0].Settings[0].Value);
                        src.CacheOption = BitmapCacheOption.OnLoad;
                        src.EndInit();
                        Gamerpic = src;
                    });
                    IsLoadingGamerpic = false;
                    AppStatus = "Done getting gamerpic!";

                    mainLogger.Debug("Got gamer picture from API");

                    AppStatus = "Waiting for you to select the device";
                    mainLogger.Debug("Waiting for user to select a device to get presence from");
                    _deviceStore.Devices = new();
                    await Task.Delay(1000);
                    if (!IsDisposing)
                    {
                        try
                        {
                            foreach (string devices in XboxPresence.Devices.Select(i => i.Type))
                            {
                                Application.Current.Dispatcher.Invoke(delegate
                                {
                                    _deviceStore.Devices.Add(devices);
                                });
                            }
                        }
                        catch (ArgumentNullException ex)
                        {
                            mainLogger.Fatal("Handled exception occurred! Could not load devices from presence ", ex);
                            AppStatus = "Could not load devices from presence!";
                            Dialog dialog = new()
                            {
                                Title = "Error!",
                                Description = "Could not load devices from presence! Go back and try again"
                            };
                            _dialogStore.ShowDialog(dialog);
                        }
                        if (_settingsHelper.Settings.QuietMode)
                        {
                            if (_deviceStore.Devices.Contains(_settingsHelper.Settings.Device))
                            {
                                LoadDevice(_settingsHelper.Settings.Device);
                            }
                            else
                            {
                                mainLogger.Info("The device specified in the settings.json file was not found online, retrying again until it becomes online...");
                                AppStatus = "The specified device was not found online, retrying again until it becomes online...";
                                if (_userStore.User.IsLimitedTo150)
                                {
                                    await Task.Delay(30000);
                                }
                                else
                                {
                                    await Task.Delay(10000);
                                }
                                LoadData(_userStore.User);
                            }
                        }
                        else
                        {
                            _deviceStore.RequestDevice();
                        }
                    }
                }
            }
        }

        private async void LoadDevice(string obj)
        {
            SelectedDevice = obj;
            if (SelectedDevice == "" || SelectedDevice is null)
            {
                AppStatus = "You didn't select a device!";
                await Task.Delay(1500);
                AppStatus = "Waiting for you to select the device";
                _deviceStore.RequestDevice();
            }
            else
            {
                AppStatus = "Device selected!";
                mainLogger.Debug("The device " + SelectedDevice + " was selected");
                _settingsHelper.Settings.Device = SelectedDevice;
                _settingsHelper.WriteSettings();
                switch (SelectedDevice)
                {
                    case "XboxOne":
                        DeviceName = "Xbox One";
                        break;
                    case "Xbox360":
                        DeviceName = "Xbox 360";
                        break;
                    case "Scarlett":
                        DeviceName = "Xbox Series X|S";
                        break;
                    case "WindowsOneCore":
                        DeviceName = "Windows";
                        break;
                    default:
                        DeviceName = "Unknown Device";
                        break;
                }
                LoadDataFromPresence();
            }
        }

        private async void LoadDataFromPresence()
        {
            Timestamps actualTimestamp = Timestamps.Now;
            string gameCache = "";
            Game game = new();
            GameInfo gameInfo = new();
            string gameWebsite = null;
            Button[] buttons = Array.Empty<Button>();
            while (!IsDisposing)
            {
                isRunning = true;
                XboxPresence = await GetPresenceAsync(XboxAccountsList);
                Status = XboxPresence.State;
                AppStatus = "Done getting presence!";
                if (Status == "Offline")
                {
                    mainLogger.Debug("User is offline");
                    try
                    {
                        Client.ClearPresence();
                    }
                    catch (Exception ex)
                    {
                        mainLogger.Fatal("Handled exception occurred! ", ex);
                    }

                    if (_settingsHelper.Settings.OfflineLookup)
                    {
                        Dialog dialog = new()
                        {
                            Title = "Error!",
                            Description = "The user is offline! Go back and try again"
                        };
                        _dialogStore.ShowDialog(dialog);
                        AppStatus = "User offline, go back and try again";
                        break;
                    }

                    if (_userStore.User.IsLimitedTo150)
                    {
                        AppStatus = "User is offline.. Checking again in 30s";
                        await Task.Delay(30000);
                    }
                    else
                    {
                        AppStatus = "User is offline.. Checking again in 10s";
                        await Task.Delay(10000);
                    }
                }
                else
                {
                    gameCache = GameTitle;
                    if (XboxPresence.Devices is null || XboxPresence is null)
                    {
                        try
                        {
                            Client.ClearPresence();
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                        AppStatus = "Got no data! Trying again...";
                        mainLogger.Debug("There was no data from the presence or account, probably an error ocurred before");
                        if (_userStore.User.IsLimitedTo150)
                        {
                            await Task.Delay(30000);
                        }
                        else
                        {
                            await Task.Delay(10000);
                        }
                        LoadDataFromPresence();
                        break;
                    }
                    AppStatus = "Getting your presence...";
                    Title newTitle = await GetGameDataFromPresenceAsync(XboxPresence.Devices);
                    if (newTitle.Name == null)
                    {
                        Dialog dialog = new()
                        {
                            Title = "Error!",
                            Description = "The selected device went offline or an error ocurred!"
                        };
                        _dialogStore.ShowDialog(dialog);
                        AppStatus = "Go back and try again";
                        try
                        {
                            Client.ClearPresence();
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                        break;
                    }
                    else
                    {
                        GameTitle = newTitle.Name;
                        if (newTitle.Activity is null)
                        {
                            if (_userStore.User.Language == "Spanish")
                            {
                                RichPresence = "En " + DeviceName;
                            }
                            else if (_userStore.User.Language == "English")
                            {
                                RichPresence = "On " + DeviceName;
                            }
                        }
                        else
                        {
                            RichPresence = newTitle.Activity.RichPresence;
                        }
                        if (GameTitle != gameCache && !IsDisposing)
                        {
                            gameInfo = await GetGameInfoAsync(newTitle.Id);
                            if (gameInfo.Products is not null)
                            {
                                await Task.Run(() =>
                                {
                                    foreach (string website in gameInfo.Products.SelectMany(i => i.LocalizedProperties).Where(i => i.PublisherWebsiteUri != "" || i.PublisherWebsiteUri is null).Select(i => i.PublisherWebsiteUri))
                                    {
                                        gameWebsite = website;
                                    }
                                });
                                if (gameWebsite is not null && !gameWebsite.Contains("https://") && !gameWebsite.Contains("http://"))
                                {
                                    gameWebsite = "https://" + gameWebsite;
                                    Button[] button =
                                    {
                                    new Button()
                                    {
                                        Label = "Game/app info",
                                        Url = gameWebsite
                                    }
                                };
                                    buttons = button;
                                }
                                else if (gameWebsite is not null && !gameWebsite.Contains("https://"))
                                {
                                    Button[] button =
                                    {
                                    new Button()
                                    {
                                        Label = "Game/app info",
                                        Url = gameWebsite
                                    }
                                };
                                    buttons = button;
                                }
                                else if (gameWebsite is not null && !gameWebsite.Contains("http://"))
                                {
                                    Button[] button =
    {
                                    new Button()
                                    {
                                        Label = "Game/app info",
                                        Url = gameWebsite
                                    }
                                };
                                    buttons = button;
                                }
                            }
                        }
                        AppStatus = "Successfully got game data!";
                        mainLogger.Debug("Got game data from API");
                        if (!_userStore.User.IsUsingSteamGridDB && !_userStore.User.IsUsingImagesAPI && GameTitle != gameCache && !IsDisposing)
                        {
                            mainLogger.Debug("Games List.json was selected, getting images from that source");
                            game = await GetGamePicturesAsync(newTitle.Name);
                        }
                        else if (_userStore.User.IsUsingSteamGridDB && GameTitle != gameCache && !IsDisposing)
                        {
                            mainLogger.Debug("SteamGridDB was selected, getting images from that source");
                            game = await GetGamePicturesFromSteamGridDBAsync(newTitle.Name);
                        }
                        else if (_userStore.User.IsUsingImagesAPI && GameTitle != gameCache && !IsDisposing && gameInfo.Products is not null)
                        {
                            mainLogger.Debug("Xbox API was selected, getting images from that source");
                            game = await GetGamePicturesFromAPI(gameInfo);
                        }
                        string gameType = "";
                        string deviceImage = "";
                        if (game.Titlename is not null)
                        {
                            if (game.Titlename == "Home")
                            {
                                if (_userStore.User.Language == "English")
                                {
                                    switch (game.Type)
                                    {
                                        case 1:
                                            gameType = "Playing ";
                                            break;
                                        case 2:
                                            gameType = "Watching ";
                                            break;
                                        case 3:
                                            gameType = "Using ";
                                            break;
                                        default:
                                            gameType = "Playing ";
                                            break;
                                    }
                                }
                                else if (_userStore.User.Language == "Spanish")
                                {
                                    switch (game.Type)
                                    {
                                        case 1:
                                            gameType = "Jugando a ";
                                            break;
                                        case 2:
                                            gameType = "Viendo ";
                                            break;
                                        case 3:
                                            gameType = "Usando ";
                                            break;
                                        default:
                                            gameType = "Jugando a ";
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    Application.Current.Dispatcher.Invoke(delegate
                                    {
                                        Uri titleIcon = new(game.Titleicon, UriKind.Absolute);
                                        BitmapImage src = new();
                                        src.BeginInit();
                                        src.UriSource = titleIcon;
                                        src.CacheOption = BitmapCacheOption.OnLoad;
                                        src.EndInit();
                                        GamePicture = src;
                                    });
                                    Application.Current.Dispatcher.Invoke(delegate
                                    {
                                        Uri titleBackground = new(game.Titlebackground, UriKind.Absolute);
                                        BitmapImage src2 = new();
                                        src2.BeginInit();
                                        src2.UriSource = titleBackground;
                                        src2.CacheOption = BitmapCacheOption.OnLoad;
                                        src2.EndInit();
                                        GameBackground = src2;
                                    });
                                }
                                catch (Exception ex)
                                {
                                    mainLogger.Fatal("Handled exception occurred! Could not load an image ", ex);
                                    AppStatus = "Could not load an image!";
                                }
                                if (_userStore.User.Language == "English")
                                {
                                    switch (game.Type)
                                    {
                                        case 1:
                                            gameType = "Playing ";
                                            break;
                                        case 2:
                                            gameType = "Watching ";
                                            break;
                                        case 3:
                                            gameType = "Using ";
                                            break;
                                        default:
                                            gameType = "Playing ";
                                            break;
                                    }
                                }
                                else if (_userStore.User.Language == "Spanish")
                                {
                                    switch (game.Type)
                                    {
                                        case 1:
                                            gameType = "Jugando a ";
                                            break;
                                        case 2:
                                            gameType = "Viendo ";
                                            break;
                                        case 3:
                                            gameType = "Usando ";
                                            break;
                                        default:
                                            gameType = "Jugando a ";
                                            break;
                                    }
                                }
                                if (game.Titleicon.Length >= 256)
                                {
                                    mainLogger.Fatal("Titleicon link is too long! (max 256 characters), try using another source or modify the titleicon if the source is from Games List.json... Game in question: " + game.Titlename);
                                    AppStatus = "Could not load game picture! Link is too long";
                                    game.Titleicon = "xbox_one";
                                }
                            }
                        }
                        else
                        {
                            game.Titleicon = "xbox_one";
                            if (_userStore.User.Language == "English")
                            {
                                switch (game.Type)
                                {
                                    case 1:
                                        gameType = "Playing ";
                                        break;
                                    case 2:
                                        gameType = "Watching ";
                                        break;
                                    case 3:
                                        gameType = "Using ";
                                        break;
                                    default:
                                        gameType = "Playing ";
                                        break;
                                }
                            }
                            else if (_userStore.User.Language == "Spanish")
                            {
                                switch (game.Type)
                                {
                                    case 1:
                                        gameType = "Jugando a ";
                                        break;
                                    case 2:
                                        gameType = "Viendo ";
                                        break;
                                    case 3:
                                        gameType = "Usando ";
                                        break;
                                    default:
                                        gameType = "Jugando a ";
                                        break;
                                }
                            }
                        }
                        switch (DeviceName)
                        {
                            case "Xbox 360":
                                deviceImage = "xbox_360";
                                break;
                            case "Xbox One":
                                deviceImage = "xbox_one";
                                break;
                            case "Xbox Series X|S":
                                deviceImage = "xbox_series";
                                break;
                            case "Windows":
                                deviceImage = "windows_10";
                                break;
                            default:
                                deviceImage = "xbox_one";
                                break;
                        }
                        IsLoadingGamePicture = false;
                        try
                        {
                            if (gameWebsite is not null)
                            {
                                Client.SetPresence(new RichPresence()
                                {
                                    Details = gameType + GameTitle,
                                    State = RichPresence,
                                    Timestamps = actualTimestamp,
                                    Assets = new Assets()
                                    {
                                        LargeImageKey = game.Titleicon,
                                        LargeImageText = GameTitle,
                                        SmallImageKey = deviceImage,
                                        SmallImageText = DeviceName
                                    },
                                    Buttons = buttons
                                });
                            }
                            else
                            {
                                Client.SetPresence(new RichPresence()
                                {
                                    Details = gameType + GameTitle,
                                    State = RichPresence,
                                    Timestamps = actualTimestamp,
                                    Assets = new Assets()
                                    {
                                        LargeImageKey = game.Titleicon,
                                        LargeImageText = GameTitle,
                                        SmallImageKey = deviceImage,
                                        SmallImageText = DeviceName
                                    }
                                });
                            }
                        }
                        catch (Exception e)
                        {
                            mainLogger.Fatal("Handled exception occurred! Happened while loading " + GameTitle + " ", e);
                            if (e is DiscordRPC.Exceptions.StringOutOfRangeException)
                            {
                                try
                                {
                                    Client.SetPresence(new RichPresence()
                                    {
                                        Details = gameType + GameTitle,
                                        State = RichPresence,
                                        Timestamps = actualTimestamp,
                                        Assets = new Assets()
                                        {
                                            LargeImageKey = "xbox_one",
                                            LargeImageText = GameTitle,
                                            SmallImageKey = deviceImage,
                                            SmallImageText = DeviceName
                                        }
                                    });
                                }
                                catch (Exception ex)
                                {
                                    mainLogger.Fatal("Handled exception occurred! Happened while loading " + GameTitle + " ", ex);
                                }
                            }
                            Debug.WriteLine(e.Message);
                        }
                        mainLogger.Debug("Finished loading presence!");
                        if (_userStore.User.IsLimitedTo150)
                        {
                            await Task.Delay(30000);
                        }
                        else
                        {
                            await Task.Delay(10000);
                        }
                    }
                }
            }
        }

        /// <summary> 
        /// Searchs the Xbox account using a gamertag
        /// </summary>  
        /// <returns>The <c>SearchAccount</c> class of the requested account or profile</returns>  
        private async Task<SearchAccount> SearchXboxAccountAsync()
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("X-Authorization", APIKey);
            string result = "";
            try
            {
                result = await client.GetStringAsync("https://xbl.io/api/v2/friends/search/" + Gamertag);
            }
            catch (Exception e)
            {
                mainLogger.Fatal("Handled exception occurred! Happened while searching accounts (" + Gamertag + ") ", e);
                if (e is NullReferenceException)
                {
                    Debug.WriteLine(e.Message);
                }
                else if (e is HttpRequestException)
                {
                    HttpRequestException httpRequestException = (HttpRequestException)e;
                    if (httpRequestException.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Dialog dialog = new()
                        {
                            Title = "Error!",
                            Description = "The Gamertag was not found! Check for any typos"
                        };
                        AppStatus = "Go back and try again";
                        _dialogStore.ShowDialog(dialog);
                        mainLogger.Debug("The Xbox account was not found (Account list from searching returned 404)");
                    }
                    else
                    {
                        Dialog dialog = new()
                        {
                            Title = "Error!",
                            Description = "There was an error while trying to connect to the API! " + e.Message
                        };
                        AppStatus = "Go back and try again";
                        _dialogStore.ShowDialog(dialog);
                        mainLogger.Fatal("Handled exception occurred! Happened while searching accounts (" + Gamertag + ") ", e);
                    }
                }
                else
                {
                    Dialog dialog = new()
                    {
                        Title = "Error!",
                        Description = "There was an error while trying to connect to the API! " + e.Message
                    };
                    AppStatus = "Go back and try again";
                    _dialogStore.ShowDialog(dialog);
                    mainLogger.Fatal("Handled exception occurred! Happened while searching accounts (" + Gamertag + ") ", e);
                }
            }

            if (result == "")
            {
                SearchAccount nullAccount = new();
                return nullAccount;
            }
            else
            {
                SearchAccount xboxAccountList = JsonConvert.DeserializeObject<SearchAccount>(result);
                AppStatus = "Found " + xboxAccountList.ProfileUsers.Count + " entries...";

                return xboxAccountList;
            }
        }

        /// <summary>  
        /// Gets the game presence to use later with GetGameDataFromPresenceAsync
        /// </summary>  
        /// <param name="accounts">The account or user profile to get the presence from</param>  
        /// <returns>The <c>Presence</c> class of the requested account or profile</returns>  
        private async Task<Presence> GetPresenceAsync(SearchAccount accounts)
        {
            Presence xboxPresence = new();
            using HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Add("X-Authorization", APIKey);
                if (_userStore.User.Language == "Spanish")
                {
                    client.DefaultRequestHeaders.Add("Accept-Language", "es-AR");
                }
                else if (_userStore.User.Language == "English")
                {
                    client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
                }
                string result = await client.GetStringAsync("https://xbl.io/api/v2/" + accounts.ProfileUsers[0].Id + "/presence");
                result = result.Substring(1, result.Length - 2);
                xboxPresence = JsonConvert.DeserializeObject<Presence>(result);

                AppStatus = "Got presence!";
            }
            catch (Exception e)
            {
                mainLogger.Fatal("Handled exception occurred! Happened while getting presence from account (" + Gamertag + ") ", e);
                if (e is NullReferenceException)
                {
                    Debug.WriteLine(e.Message);
                }
                else
                {
                    Dialog dialog = new()
                    {
                        Title = "Error!",
                        Description = "There was an error while trying to connect to the API! " + e.Message
                    };
                    AppStatus = "Go back and try again";
                    _dialogStore.ShowDialog(dialog);
                }
            }
            return xboxPresence;
        }

        /// <summary>  
        /// Gets the game data such as the <c>Name</c> and <c>RichPresence</c>
        /// </summary>  
        /// <param name="devices">The list of devices to get the presence from</param>  
        /// <returns>The <c>Title</c> class of the requested game</returns>  
        private async Task<Title> GetGameDataFromPresenceAsync(List<Device> devices)
        {
            Title newTitle = new();
            await Task.Run(() =>
            {
                foreach (Title title in devices.Where(t => t.Type == SelectedDevice).SelectMany(t => t.Titles).Where(t => t.Placement == "Full"))
                {
                    newTitle = title;
                }
            });

            if (newTitle.Name is null)
            {
                await Task.Run(() =>
                {
                    foreach (Title alternativeTitle in devices.Where(t => t.Type == SelectedDevice).SelectMany(t => t.Titles))
                    {
                        newTitle = alternativeTitle;
                    }
                });
            }

            if (newTitle.Name is null)
            {
                AppStatus = "The selected device is no longer online!";
            }
            else
            {
                AppStatus = "Got the game data!";
            }
            return newTitle;
        }

        /// <summary>  
        /// Gets the game pictures using the Games List.json
        /// </summary>  
        /// <param name="titlename">The name of the game</param>  
        /// <returns>The <c>Game</c> class with the pictures of the requested game</returns>  
        private async Task<Game> GetGamePicturesAsync(string titlename)
        {
            using HttpClient client = new();
            Game finalGame = new();
            titlename = titlename.Replace("®", "");
            titlename = titlename.Replace("©", "");
            titlename = titlename.Replace("™", "");
            titlename = titlename.Replace("?", "");
            try
            {
                string result = await client.GetStringAsync("https://raw.githubusercontent.com/MrCoolAndroid/Xbox-Rich-Presence-Discord/main/Games%20List.json");
                Games gamesList = JsonConvert.DeserializeObject<Games>(result);
                await Task.Run(() =>
                {
                    foreach (Game game in gamesList.GamesList.SelectMany(t => t.Games).Where(t => t.Titlename == titlename))
                    {
                        finalGame = game;
                    }
                });
                return finalGame;
            }
            catch (Exception e)
            {
                mainLogger.Fatal("Handled exception occurred! Happened while getting game pictures from Games List.json ", e);
                AppStatus = "Could not get game picture!";
                return finalGame;
            }
        }

        /// <summary>  
        /// Gets the game pictures using SteamGridDB
        /// </summary>  
        /// <param name="titlename">The name of the game</param>  
        /// <returns>The <c>Game</c> class with the pictures of the requested game</returns>  
        private async Task<Game> GetGamePicturesFromSteamGridDBAsync(string titlename)
        {
            titlename = titlename.Replace("®", "");
            titlename = titlename.Replace("©", "");
            titlename = titlename.Replace("™", "");
            titlename = titlename.Replace("?", "");

            Ignore ignoreList = new();
            List<string> ignoreStrings = new();
            using HttpClient client = new();
            try
            {
                string result = await client.GetStringAsync("https://raw.githubusercontent.com/MrCoolAndroid/Xbox-Rich-Presence-Discord/main/Ignore%20List.json");
                ignoreList = JsonConvert.DeserializeObject<Ignore>(result);
            }
            catch (Exception e)
            {
                mainLogger.Fatal("Handled exception occurred! Happened while getting Ignore List.json ", e);
                AppStatus = "Could not get game picture!";
            }

            await Task.Run(() =>
            {
                foreach (IgnoreList list in ignoreList.IgnoreList.Where(i => i.Titlename == titlename))
                {
                    ignoreStrings = list.Ignore;
                }
            });

            if (ignoreStrings.Count != 0 || ignoreStrings is null)
            {
                if (ignoreStrings.Any(titlename.Contains))
                {
                    await Task.Run(() =>
                    {
                        foreach (string ignore in ignoreStrings)
                        {
                            titlename = titlename.Replace(ignore, "");
                        }
                    });
                }
            }

            Game game = new();
            SteamGridDbGame dbGame = new();
            SteamGridDbGrid dbGrid = new();
            AppStatus = "Getting images from SteamGridDB";
            try
            {
                SteamGridDbGame[]? games = await sgdb.SearchForGamesAsync(titlename);
                dbGame = games[0];
                AppStatus = "Got game info";
                SteamGridDbGrid[]? grids = await sgdb.GetGridsByGameIdAsync(dbGame.Id);
                await Task.Run(() =>
                {
                    foreach (SteamGridDbGrid steamGridDbGrid in grids.Where(i => i.Height == 1024 && i.Width == 1024))
                    {
                        dbGrid = steamGridDbGrid;
                    }
                });
                AppStatus = "Got game grids";
                SteamGridDbHero[]? heroes = await sgdb.GetHeroesByGameIdAsync(dbGame.Id);
                AppStatus = "Got game heroes";
                game.Titlename = dbGame.Name;
                game.Titleicon = dbGrid.FullImageUrl;
                game.Titlebackground = heroes[0].FullImageUrl;
                game.Titleimage = dbGame.Name;
                game.Type = 1;

                if (game.Titleicon is null)
                {
                    game.Titleicon = "xbox_one";
                }

                AppStatus = "Done getting SteamGridDB info";

                return game;
            }
            catch (Exception e)
            {
                mainLogger.Fatal("Handled exception occurred! Happened while getting images from SteamGridDB ", e);
                Dialog dialog = new()
                {
                    Title = "Error!",
                    Description = "There was an error while getting the image from SteamGridDB: " + e.Message
                };
                _dialogStore.ShowDialog(dialog);
                return game;
            }
        }

        /// <summary>  
        /// Gets the game information by using its TitleID
        /// </summary>  
        /// <param name="titleID">The TitleID of the game</param>  
        /// <returns>The <c>GameInfo</c> of the requested game</returns>  
        private async Task<GameInfo> GetGameInfoAsync(long titleID)
        {
            AppStatus = "Getting game info from API";
            GameInfo gameInfo = new();
            using HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Add("X-Authorization", APIKey);
                if (_userStore.User.Language == "Spanish")
                {
                    client.DefaultRequestHeaders.Add("Accept-Language", "es-AR");
                }
                else if (_userStore.User.Language == "English")
                {
                    client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
                }
                string result = await client.GetStringAsync("https://xbl.io/api/v2/marketplace/title/" + titleID);
                gameInfo = JsonConvert.DeserializeObject<GameInfo>(result);

                AppStatus = "Got game info!";
                return gameInfo;
            }
            catch (Exception e)
            {
                mainLogger.Fatal("Handled exception occurred! Happened while getting game info ", e);
                AppStatus = "Could not get game info!";
                Debug.WriteLine(e.Message);
                return gameInfo;
            }
        }

        /// <summary>  
        /// Gets game pictures from the xbl.io API
        /// </summary>  
        /// <param name="gameInfo">The <c>GameInfo</c> of the game</param>  
        /// <returns>The <c>Game</c> class with the pictures of the requested game</returns>  
        private async Task<Game> GetGamePicturesFromAPI(GameInfo gameInfo)
        {
            Game game = new();
            AppStatus = "Getting game pictures from API";
            await Task.Run(() =>
            {
                foreach (Image image in gameInfo.Products.SelectMany(i => i.LocalizedProperties).SelectMany(i => i.Images).Where(i => i.ImagePurpose == "BoxArt"))
                {
                    if (!image.Uri.Contains("https:") && !image.Uri.Contains("http:"))
                    {
                        game.Titleicon = "https:" + image.Uri;
                    }
                    else
                    {
                        game.Titleicon = image.Uri;
                    }
                }
            });
            await Task.Run(() =>
            {
                foreach (Image image in gameInfo.Products.SelectMany(i => i.LocalizedProperties).SelectMany(i => i.Images).Where(i => i.ImagePurpose == "SuperHeroArt"))
                {
                    if (!image.Uri.Contains("https:") && !image.Uri.Contains("http:"))
                    {
                        game.Titlebackground = "https:" + image.Uri;
                    }
                    else
                    {
                        game.Titlebackground = image.Uri;
                    }
                }
            });
            await Task.Run(() =>
            {
                foreach (string titlename in gameInfo.Products.SelectMany(i => i.LocalizedProperties).Select(i => i.ProductTitle))
                {
                    game.Titlename = titlename;
                }
            });
            await Task.Run(() =>
            {
                foreach (string type in gameInfo.Products.Select(i => i.ProductFamily))
                {
                    switch (type)
                    {
                        case "Games":
                            game.Type = 1;
                            break;
                        case "Apps":
                            game.Type = 3;
                            break;
                        default:
                            game.Type = 1;
                            break;
                    }
                }
            });
            if (game.Titleicon is not null && game.Titleicon.Length >= 256)
            {
                await Task.Run(() =>
                {
                    List<string> list =
                    [
                        "BoxArt",
                        "AppIconSquareArt",
                        "Icon",
                        "Tile"
                    ];
                    foreach (Image image in gameInfo.Products.SelectMany(i => i.LocalizedProperties).SelectMany(i => i.Images).Where(i => i.Height >= 400 && i.Width >= 400 && i.Uri.Length < 256 && list.Contains(i.ImagePurpose)))
                    {
                        if (!image.Uri.Contains("https:"))
                        {
                            game.Titleicon = "https:" + image.Uri;
                        }
                        else
                        {
                            game.Titleicon = image.Uri;
                        }
                    }
                });
            }
            if (game.Titleicon is null && gameInfo.Products.Count >= 1)
            {
                await Task.Run(() =>
                {
                    foreach (Image image in gameInfo.Products.SelectMany(i => i.LocalizedProperties).SelectMany(i => i.Images).Where(i => i.ImagePurpose == "Tile" && i.Height >= 400 && i.Width >= 400))
                    {
                        if (!image.Uri.Contains("https:"))
                        {
                            game.Titleicon = "https:" + image.Uri;
                        }
                        else
                        {
                            game.Titleicon = image.Uri;
                        }
                    }
                });
            }

            AppStatus = "Got game pictures from API";
            return game;
        }

        private class UserColor
        {
            public string primaryColor { get; set; }
            public string secondaryColor { get; set; }
            public string tertiaryColor { get; set; }
        }

        public override void Dispose()
        {
            _navigationStore.ViewChanged -= OnViewChanged;
            Client.OnReady -= OnDiscordConnectionReady;
            Client.OnConnectionFailed -= OnDiscordConnectionFailed;
            Client.Dispose();
            XboxPresence = new();
            XboxAccountsList = new();
            IsDisposing = true;
            UserConfiguration.Default.Save();
            base.Dispose();
        }
    }
}
