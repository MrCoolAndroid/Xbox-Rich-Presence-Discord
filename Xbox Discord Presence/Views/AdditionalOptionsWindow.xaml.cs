using System.Windows;

namespace Xbox_Discord_Presence.Views
{
    public partial class AdditionalOptionsWindow : Window
    {
        public AdditionalOptionsWindow(object dataContext)
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }
    }
}
