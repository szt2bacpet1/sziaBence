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
using System.Windows;
using System.Windows.Media;
using System;
using System.Linq;

namespace Flyhigh.Desktop.ViewModels.Legijaratok
{
    public partial class GepAdatokViewModel : BaseViewModel
    {
        private readonly IGepService? _gepService;
        private readonly IGepAdatokTipusService? _tipusService;


        [ObservableProperty]
        private ObservableCollection<GepAdatok> _gepek = new();

        [ObservableProperty]
        private ObservableCollection<GepAdatokTipus> _gepadatoktipusok = new();


        [ObservableProperty]
        private GepAdatok _selectedGepek;

        [ObservableProperty]
        private string keresesSzoveg;


        public uint FilteredMinTurista { get; set; } = 0;
        public uint FilteredMaxTurista { get; set; } = uint.MaxValue;
        public string SearchedName { get; set; } = string.Empty;

        public GepAdatokViewModel()
        {
            _selectedGepek = new GepAdatok();

            keresesSzoveg = string.Empty;
        }

        public GepAdatokViewModel(IGepService? gepSer, IGepAdatokTipusService gepAdatokTipusService)
        {
            SelectedGepek = new GepAdatok();

            _gepService = gepSer;
            _tipusService = gepAdatokTipusService;

            keresesSzoveg = string.Empty;
        }

        [RelayCommand]
        public async Task DoSave(GepAdatok newGep)
        {
            if (_gepService is not null)
            {
                ControllerResponse result = new();
                if (newGep.HasId)
                    result = await _gepService.UpdateAsync(newGep);
                else
                    result = await _gepService.InsertAsync(newGep);

                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        void DoNewStudent()
        {
            SelectedGepek = new GepAdatok();
        }

        [RelayCommand]
        public async Task DoSearch()
        {
            if (string.IsNullOrWhiteSpace(KeresesSzoveg))
            {
                MessageBox.Show("Kérlek add meg a gép nevét!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_gepService is not null)
            {
                List<GepAdatok> talalatok = await _gepService.SearchGep(KeresesSzoveg);
                Gepek = new ObservableCollection<GepAdatok>(talalatok);

                if (talalatok.Count == 0)
                {
                    MessageBox.Show("Nincs találat a keresésre.", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        [RelayCommand]
        public async Task DoDelete(GepAdatok gepekdel)
        {
            if (_gepService is not null)
            {
                ControllerResponse result = await _gepService.DeleteAsync(gepekdel.Id);
                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        public override async Task InitializeAsync()
        {
            await UpdateView();
        }

        private async Task UpdateView(bool reloadData = true)
        {
            if (_gepService is not null)
            {
                if (reloadData)
                {
                    List<GepAdatok> gepeks = await _gepService.SelectAllIncludedAsync();
                    Gepek = new ObservableCollection<GepAdatok>(gepeks);
                }
                SetFilteredMinMax();
            }
            if (_tipusService is not null)
            {
                if (reloadData)
                {
                    List<GepAdatokTipus> tipusok = await _tipusService.SelectAllAsync();
                    Gepadatoktipusok = new ObservableCollection<GepAdatokTipus>(tipusok);
                }
            }
        }


        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_gepService != null)
            {
                List<GepAdatok> gepek = await _gepService.SearchAndFilterGepek(this.ToGepQueryParameters());
                Gepek = new ObservableCollection<GepAdatok>(gepek);
                await UpdateView(false);
            }
        }

        [RelayCommand]
        private async Task DoResetFilterAndSerachParameter()
        {
            SearchedName = string.Empty;
            FilteredMinTurista = 0;
            FilteredMaxTurista = uint.MaxValue;
            await InitializeAsync();
        }
        private void SetFilteredMinMax()
        {
            if (Gepek is not null && Gepek.Any())
            {
                FilteredMinTurista = (uint)Gepek.ToList().Select(gep => gep.Foglaltturista).Min();
                FilteredMaxTurista = (uint)Gepek.ToList().Select(gep => gep.Foglaltturista).Max();
            }
            else
            {
                FilteredMinTurista = FilteredMaxTurista = 0;
            }
        }



    }
}
