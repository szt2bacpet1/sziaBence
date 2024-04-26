using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Flyhigh.HttpService.Service;
using Flyhigh.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.Felhasznalok
{
    public partial class JogosultsagokViewModel : BaseViewModelWithAsyncInitialization
    {        
        private readonly IJogosultsagokService? _felhasznaloService;

        [ObservableProperty]
        private ObservableCollection<Felhasznalo> _felhasznalok = new ObservableCollection<Felhasznalo>();

        [ObservableProperty]
        private ObservableCollection<string> _educationLevels = new();


        [ObservableProperty]
        private Felhasznalo _selectedFelhasznalo;

        private string _selectedEducationLevel = string.Empty;
        public string SelectedEducationLevel
        {
            get => _selectedEducationLevel;
            set
            {
                SetProperty(ref _selectedEducationLevel, value);
                SelectedFelhasznalo.JogosultsagiSzint = _selectedEducationLevel;
            }
        }

        public JogosultsagokViewModel()
        {
            SelectedFelhasznalo = new Felhasznalo();
        }

        public JogosultsagokViewModel(IJogosultsagokService? felhasznaloService)
        {
            //Felhasznalok.Add(new Felhasznalo("Elek", "Teszt", System.DateTime.Now, 9, SchoolClassType.ClassA, ""));
            SelectedFelhasznalo = new Felhasznalo();

            _felhasznaloService = felhasznaloService;
        }

        [RelayCommand]
        public async Task DoSave(Felhasznalo newFelhasznalo)
        {
            if (_felhasznaloService is not null)
            {
                ControllerResponse result = await _felhasznaloService.Update(newFelhasznalo.ToFelhasznaloDto());
                await UpdateView();
            }
            OnPropertyChanged(nameof(Felhasznalok));
        }


        [RelayCommand]
        void DoNewFelhasznalo()
        {
            SelectedFelhasznalo = new Felhasznalo();
        }

        [RelayCommand]
        public void DoRemove(Felhasznalo felhasznaloToDelete)
        {
            Felhasznalok.Remove(felhasznaloToDelete);
            OnPropertyChanged(nameof(Felhasznalok));
        }

        public string SearchedName { get; set; } = string.Empty;


        public override async Task InitializeAsync()
        {
            if (_felhasznaloService is not null)
            {
                await UpdateView();
            }                   
        }

        private async Task UpdateView(bool reloadData = true)
        {
            if (_felhasznaloService is not null)
            {
                if (reloadData)
                {
                    List<Felhasznalo> felhasznalo = await _felhasznaloService.SelectAllFelhasznalo();
                    Felhasznalok = new ObservableCollection<Felhasznalo>(felhasznalo);
                }
            }
        }

        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_felhasznaloService != null)
            {
                List<Felhasznalo> felhasznalos = await _felhasznaloService.SearchAndFilterFelhasznalo(this.ToFelhasznaloQueryParameters());
                Felhasznalok = new ObservableCollection<Felhasznalo>(felhasznalos);
                await UpdateView(false);
            }
        }
        [RelayCommand]
        private async Task DoResetFilterAndSerachParameter()
        {
            SearchedName = string.Empty;
            await InitializeAsync();
        }

    }
}
