using MahApps.Metro.Controls;
using System;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Xbox_Discord_Presence.Models;

namespace Xbox_Discord_Presence
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TaskbarIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (IsVisible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }
}
