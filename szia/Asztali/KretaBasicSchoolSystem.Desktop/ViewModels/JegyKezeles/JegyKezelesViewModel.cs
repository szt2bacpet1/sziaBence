using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flyhigh.Desktop.ViewModels.Base;
using Flyhigh.Desktop.ViewModels.Legijaratok;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.JegyKezeles
{
    public partial class JegyKezelesViewModel : BaseViewModel
    {
        private JegyViewModel _jViewModel;

        public JegyKezelesViewModel()
        {
            _jViewModel = new JegyViewModel();

            CurrentChildViewModel = _jViewModel;
        }

        public JegyKezelesViewModel(
            JegyViewModel JegyKezelesViewModel
            )
        {
            _jViewModel = JegyKezelesViewModel;

            CurrentChildViewModel = _jViewModel;
        }

        [ObservableProperty]
        private BaseViewModel _currentChildViewModel;

        [RelayCommand]
        private async Task ShowJegykezeles()
        {
            await _jViewModel.InitializeAsync();
            CurrentChildViewModel = _jViewModel;
        }

    }
}
