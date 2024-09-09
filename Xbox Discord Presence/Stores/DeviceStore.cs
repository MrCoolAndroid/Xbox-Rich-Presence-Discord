using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Stores
{
    public class DeviceStore
    {
        public List<string> Devices { get; set; }
        public string SelectedDevice { get; set; }

        public event Action<string> OnDeviceSelected;
        public event Action OnRequestDevices;

        public void SelectDevice(string device)
        {
            OnDeviceSelected?.Invoke(device);
        }

        public void RequestDevice()
        {
            OnRequestDevices?.Invoke();
        }
    }
}
