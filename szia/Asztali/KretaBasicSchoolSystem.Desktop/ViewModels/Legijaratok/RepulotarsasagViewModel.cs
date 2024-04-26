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

namespace Flyhigh.Desktop.ViewModels.Legijaratok
{
    public partial class RepulotarsasagViewModel : BaseViewModelWithAsyncInitialization
    {
        private readonly IReptarsService? _reptarsService;

        [ObservableProperty]
        private ObservableCollection<Repulotarsasag> _reptarsak = new ObservableCollection<Repulotarsasag>();

		[ObservableProperty]
		private ObservableCollection<string> _allAirportCountries = new ObservableCollection<string>(new Countries().AllAirportCountry);


		[ObservableProperty]
        private Repulotarsasag _selectedRepulotarsasag;

        private string _selectedCountry = string.Empty;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                SetProperty(ref _selectedCountry, value);
                SelectedRepulotarsasag.Country = _selectedCountry;
            }
        }

        public string SearchedName { get; set; } = string.Empty;



        public RepulotarsasagViewModel()
        {
            SelectedRepulotarsasag = new Repulotarsasag();
        }

        public RepulotarsasagViewModel(IReptarsService? reptarsService)
        {
            SelectedRepulotarsasag = new Repulotarsasag();

            _reptarsService = reptarsService;
        }

        [RelayCommand]
        public async Task DoSave(Repulotarsasag newReptars)
        {
            if (_reptarsService is not null)
            {
                ControllerResponse result = new();
                if (newReptars.HasId)
                    result = await _reptarsService.Update(newReptars.ToRepuloDto());
                else
                    result = await _reptarsService.InsertAsync(newReptars);
                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        void DoNewReptarsakCommand()
        {
            SelectedRepulotarsasag = new Repulotarsasag();
        }

        [RelayCommand]
        public async Task DoRemove(Repulotarsasag reptarsToDelete)
        {
            if (_reptarsService is not null)
            {
                ControllerResponse result = await _reptarsService.RemoveAsync(reptarsToDelete.Id);
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
            if (_reptarsService is not null)
            {
                if(reloadData) 
                { 
                    List<Repulotarsasag> repulok = await _reptarsService.SelectAllReptars();
                    Reptarsak = new ObservableCollection<Repulotarsasag>(repulok);
                }
            }
        }

        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_reptarsService != null)
            {
                List<Repulotarsasag> repulotarsasags = await _reptarsService.SearchAndFilterReptars(this.ToReptarsQueryParameters());
                Reptarsak = new ObservableCollection<Repulotarsasag>(repulotarsasags);
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
