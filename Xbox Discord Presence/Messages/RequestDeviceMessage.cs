using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Models;

namespace Xbox_Discord_Presence.Messages
{
    public class RequestDeviceMessage : ValueChangedMessage<List<Device>>
    {
        public RequestDeviceMessage(List<Device> devices) : base(devices)
        {

        }
    }
}
