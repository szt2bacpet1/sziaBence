using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flyhigh.HttpService.Service;
using Flyhigh.Desktop.ViewModels.Base;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.Felhasznalok
{
    public partial class FelhasznalokViewModel : BaseViewModel
    {
        private JogosultsagokViewModel _JogosultsagokViewModel;
        private TeacherViewModel _teacherViewModel;

        public FelhasznalokViewModel()
        {
            IJogosultsagokService felhasznaloService = new JogosultsagokService(null);
            _JogosultsagokViewModel = new JogosultsagokViewModel(felhasznaloService);
            _teacherViewModel = new TeacherViewModel();

            CurrentChildViewModel = new TeacherViewModel();
        }

        public FelhasznalokViewModel(JogosultsagokViewModel JogosultsagokViewModel, TeacherViewModel teacherViewModel)
        {
            _JogosultsagokViewModel = JogosultsagokViewModel;
            _teacherViewModel = teacherViewModel;

            CurrentChildViewModel = new TeacherViewModel();
        }

        [ObservableProperty]
        private BaseViewModel _currentChildViewModel;

        [RelayCommand]
        public async Task ShowJogosultsagokView()
        {
            await _JogosultsagokViewModel.InitializeAsync();
            CurrentChildViewModel = _JogosultsagokViewModel;
        }


        [RelayCommand]
        public void ShowTeacherView()
        {
            CurrentChildViewModel = _teacherViewModel;
        }
    }
}
