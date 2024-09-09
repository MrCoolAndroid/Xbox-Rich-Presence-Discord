using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xbox_Discord_Presence.Messages
{
    public class ChangeViewMessage : ValueChangedMessage<ObservableObject>
    {
        public ChangeViewMessage(ObservableObject currentView) : base(currentView)
        {

        }
    }
}
