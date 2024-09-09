using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Messages;
using Xbox_Discord_Presence.Models;
using Xbox_Discord_Presence.Stores;

namespace Xbox_Discord_Presence.ViewModels
{
    public class RequestDeviceDialogViewModel : ViewModelBase
    {
        private readonly DeviceStore _deviceStore;

        private string[] devicesList;
        public string[] DevicesList
        {
            get => devicesList;
            set
            {
                devicesList = value;
                OnPropertyChanged(nameof(DevicesList));
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

        public RelayCommand SelectDevice { get; set;  }
        private bool CanSelectDevice = true;

        public RequestDeviceDialogViewModel(DeviceStore deviceStore)
        {
            _deviceStore = deviceStore;
            SelectDevice = new RelayCommand(SelectDeviceCommand, CanSelect);
            DevicesList = _deviceStore.Devices.ToArray();
        }

        private bool CanSelect()
        {
            return CanSelectDevice;
        }

        private void SelectDeviceCommand()
        {
            CanSelectDevice = false;
            _deviceStore.SelectDevice(SelectedDevice);
        }
    }
}
