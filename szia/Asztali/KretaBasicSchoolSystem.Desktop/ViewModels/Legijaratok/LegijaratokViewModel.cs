using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flyhigh.HttpService.Service;
using Flyhigh.Desktop.ViewModels.Base;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.Legijaratok
{
    public partial class LegijaratokViewModel : BaseViewModel
    {
        private GepAdatokViewModel _gepAdatokViewModel;
        private TaughtClassesViewModel _taughtClassesViewModel;
        private RepulotarsasagViewModel _RepulotarsasagViewModel;

        public LegijaratokViewModel()
        {
            _gepAdatokViewModel = new GepAdatokViewModel();
            _taughtClassesViewModel = new TaughtClassesViewModel();
            IReptarsService reptarsService = new ReptarsService(null);
            _RepulotarsasagViewModel = new RepulotarsasagViewModel(reptarsService);

        }

        public LegijaratokViewModel(
            GepAdatokViewModel currentSchoolHoursViewModel,
            TaughtClassesViewModel taughtClassesViewModel,
            RepulotarsasagViewModel RepulotarsasagViewModel)
        {
            _gepAdatokViewModel = currentSchoolHoursViewModel;
            _taughtClassesViewModel = taughtClassesViewModel;
            _RepulotarsasagViewModel = RepulotarsasagViewModel;

            CurrentChildViewModel = new RepulotarsasagViewModel();
        }

        [ObservableProperty]
        private BaseViewModel _currentChildViewModel;

        [RelayCommand]
        public async Task ShowGepAdatok()
        {
            await _gepAdatokViewModel.InitializeAsync();
            CurrentChildViewModel = _gepAdatokViewModel;
        }

        [RelayCommand]
        public async Task ShowTaughtClasses()
        {
            await _RepulotarsasagViewModel.InitializeAsync();
            CurrentChildViewModel = _taughtClassesViewModel;
        }

        [RelayCommand]
        public void ShowClosingSemesterGrade()
        {
            CurrentChildViewModel = _RepulotarsasagViewModel;
        }

    }
}
