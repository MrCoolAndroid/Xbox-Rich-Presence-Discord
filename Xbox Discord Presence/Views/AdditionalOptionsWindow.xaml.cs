using System.Windows;
using System.IO;
using System;

namespace Xbox_Discord_Presence.Views
{
    public partial class AdditionalOptionsWindow : Window
    {
        public AdditionalOptionsWindow(object dataContext)
        {
            InitializeComponent();
            this.DataContext = dataContext;
            Loaded += (s, e) =>
            {
                if (FindName("StartOnStartupCheckBox") is System.Windows.Controls.CheckBox checkBox)
                {
                    if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Xbox Discord Presence.lnk")))
                        checkBox.IsChecked = true;
                }
            };
        }
    }
}
