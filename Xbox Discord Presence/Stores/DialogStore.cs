using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Models;

namespace Xbox_Discord_Presence.Stores
{
    public class DialogStore
    {
        public event Action<Dialog> DialogCreated;

        public void ShowDialog(Dialog dialog)
        {
            DialogCreated?.Invoke(dialog);
        }
    }
}
