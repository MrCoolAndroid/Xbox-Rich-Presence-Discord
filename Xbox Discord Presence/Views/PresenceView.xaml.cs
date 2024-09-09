using CommunityToolkit.Mvvm.Messaging;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xbox_Discord_Presence.Messages;
using Xbox_Discord_Presence.Models;
using Xbox_Discord_Presence.ViewModels;

namespace Xbox_Discord_Presence.Views
{
    /// <summary>
    /// Lógica de interacción para PresenceView.xaml
    /// </summary>
    public partial class PresenceView : UserControl
    {
        public PresenceView()
        {
            InitializeComponent();
            SetDialog();
        }

        public async void SetDialog()
        {
            await Task.Delay(2000);
            DialogCoordinatorClass dialogCoordinatorClass = new();
            dialogCoordinatorClass.DialogCoordinator = DialogCoordinator.Instance;
            dialogCoordinatorClass.PresenceView = this;
            WeakReferenceMessenger.Default.Send(new DialogCoordinatorMessage(dialogCoordinatorClass));
        }
    }
}
