using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Models;

namespace Xbox_Discord_Presence.Messages
{
    public class InitialMessage : ValueChangedMessage<InitialClass>
    {
        public InitialMessage(InitialClass initialClass) : base(initialClass)
        {

        }
    }
}
