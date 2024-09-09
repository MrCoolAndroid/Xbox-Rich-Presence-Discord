using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Messages
{
    public class SendDeviceMessage : ValueChangedMessage<string>
    {
        public SendDeviceMessage(string device) : base(device)
        {
                
        }
    }
}
