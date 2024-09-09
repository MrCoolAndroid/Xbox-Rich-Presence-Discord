using CommunityToolkit.Mvvm.Messaging.Messages;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Models;

namespace Xbox_Discord_Presence.Messages
{
    public class DialogCoordinatorMessage : ValueChangedMessage<DialogCoordinatorClass>
    {
        public DialogCoordinatorMessage(DialogCoordinatorClass dialogCoordinator) : base(dialogCoordinator)
        {

        }
    }
}
