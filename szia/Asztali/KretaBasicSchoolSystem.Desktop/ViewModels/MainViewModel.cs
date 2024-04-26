using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FontAwesome.Sharp;
using Flyhigh.Desktop.ViewModels.Base;
using Flyhigh.Desktop.ViewModels.ControlPanel;
using Flyhigh.Desktop.ViewModels.Felhasznalok;
using Flyhigh.Desktop.ViewModels.JegyKezeles;
using Flyhigh.Desktop.ViewModels.Legijaratok;
using Flyhigh.Desktop.ViewModels.Administration;

namespace Flyhigh.Desktop.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ControlPanelViewModel _controlPanelViewModel;
        private FelhasznalokViewModel _FelhasznalokViewModel;
        private JegyKezelesViewModel _JegyKezelesViewModel;
        private LegijaratokViewModel _legijaratokViewModel;
        private AdministrationViewModel _administrationViewModel;


        public MainViewModel()
        {
            _controlPanelViewModel = new ControlPanelViewModel();
            _FelhasznalokViewModel = new FelhasznalokViewModel();
            _JegyKezelesViewModel = new JegyKezelesViewModel();
            _legijaratokViewModel = new LegijaratokViewModel();
            _administrationViewModel = new AdministrationViewModel();

            _currentChildView = new ControlPanelViewModel();

        }

        public MainViewModel(
            ControlPanelViewModel controlPanelViewModel,
            FelhasznalokViewModel FelhasznalokViewModel,
            JegyKezelesViewModel JegyKezelesViewModel,
            LegijaratokViewModel schoolGradeViewModel,
            AdministrationViewModel administrationViewModel

            )
        {
            _controlPanelViewModel = controlPanelViewModel;
            _FelhasznalokViewModel = FelhasznalokViewModel;
            _JegyKezelesViewModel = JegyKezelesViewModel;
            _legijaratokViewModel = schoolGradeViewModel;
            _administrationViewModel = administrationViewModel;



            CurrentChildView = _controlPanelViewModel;
            ShowDashbord();
        }

        [ObservableProperty]
        private string _caption = string.Empty;

        [ObservableProperty]
        private IconChar _icon = new IconChar();

        [ObservableProperty]
        private BaseViewModel _currentChildView;

        [RelayCommand]
        public void ShowDashbord()
        {
            Caption = "Kezdőlap";
            Icon = IconChar.Home;
            CurrentChildView = _controlPanelViewModel;
        }

        [RelayCommand]
        public void ShowFelhasznalok()
        {
            Caption = "Felhasználók";
            Icon = IconChar.UserGroup;
            CurrentChildView = _FelhasznalokViewModel;
        }

        [RelayCommand]
        public void ShowSchoolClasses()
        {
            Caption = "Légijáratok";
            Icon = IconChar.Plane;
            CurrentChildView = _legijaratokViewModel; ;
        }

        [RelayCommand]
        public void ShowJegyKezeles()
        {
            Caption = "Jegykezelés";
            Icon = IconChar.Ticket;
            CurrentChildView = _JegyKezelesViewModel;
        }

        [RelayCommand]
        public void ShowAdministration()
        {
            Caption = "Adminisztrációs feladatok";
            Icon = IconChar.Computer;
            CurrentChildView = _administrationViewModel;
        }

    }
}
