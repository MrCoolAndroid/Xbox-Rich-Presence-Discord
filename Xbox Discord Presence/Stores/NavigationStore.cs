using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbox_Discord_Presence.Models;

namespace Xbox_Discord_Presence.Stores
{
    public class NavigationStore
    {
        public event Action<ViewModelBase> ViewChanged;

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel?.Dispose();
                currentViewModel = value;
                OnCurrentViewModelChanged(value);
            }
        }

        private void OnCurrentViewModelChanged(ViewModelBase currentView)
        {
            ViewChanged?.Invoke(currentView);
        }
    }
}
