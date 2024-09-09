using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Models;

namespace Xbox_Discord_Presence.Stores
{
    public class ThemeStore
    {
        public event Action<string> ColorChanged;

        public void ChangeColor(string color)
        {
            ColorChanged?.Invoke(color);
        }
    }
}
