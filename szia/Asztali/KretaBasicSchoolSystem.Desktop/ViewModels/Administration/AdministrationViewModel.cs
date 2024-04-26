using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flyhigh.Desktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.Administration
{
    public partial class AdministrationViewModel : BaseViewModel
    {
        private GepAdatokTipusViewModel _gepadatoktipus = new();

        [ObservableProperty]
        private BaseViewModel _currentAdministrationChildView;

        public AdministrationViewModel()
        {
            _currentAdministrationChildView = _gepadatoktipus;
        }

        public AdministrationViewModel(GepAdatokTipusViewModel gepadatoktipus)
        {
            _gepadatoktipus = gepadatoktipus;
            CurrentAdministrationChildView = _gepadatoktipus;
            CurrentAdministrationChildView.InitializeAsync();
        }

        [RelayCommand]
        private async Task ShowGepAdatTipus()
        {
            CurrentAdministrationChildView = _gepadatoktipus;
            await _gepadatoktipus.InitializeAsync();
        }
    }
}
