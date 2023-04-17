using Wpf.Ui.Common.Interfaces;

namespace Spyware_Detection_System.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : INavigableView<ViewModels.SettingsViewModel>
    {
        public ViewModels.SettingsViewModel ViewModel
        {
            get;
        }

        public SettingsPage(ViewModels.SettingsViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}