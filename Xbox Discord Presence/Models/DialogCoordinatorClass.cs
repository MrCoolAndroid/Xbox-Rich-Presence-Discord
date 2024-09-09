using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Views;

namespace Xbox_Discord_Presence.Models
{
    public class DialogCoordinatorClass
    {
        public IDialogCoordinator DialogCoordinator { get; set; }
        public PresenceView PresenceView { get; set; }
    }
}
