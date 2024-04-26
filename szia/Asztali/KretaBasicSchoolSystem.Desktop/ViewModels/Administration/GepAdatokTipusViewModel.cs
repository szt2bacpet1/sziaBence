using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flyhigh.Desktop.ViewModels.Base;
using Flyhigh.HttpService.Service;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.Administration
{
    public partial class GepAdatokTipusViewModel : BaseViewModel
    {
        private readonly IGepAdatokTipusService? _gepadatoktipusservie;
        private readonly IGepService? _gepservice;
        public string Title { get; set; } = "GepAdatok tipusai kezelése";

        [ObservableProperty]
        private ObservableCollection<GepAdatokTipus> _gepadatokTipus = new();

        [ObservableProperty]
        private GepAdatokTipus _selectedtipus = new();

        [ObservableProperty]
        private ObservableCollection<GepAdatok> _gepekWithGepTipus = new();

        [ObservableProperty]
        private GepAdatok _selectedGepekWithGepTipus = new();

        [ObservableProperty]
        private ObservableCollection<GepAdatok> _gepekWithoutTipus = new();

        [ObservableProperty]
        private GepAdatok _selectedGepekWithoutTipus = new();



        public GepAdatokTipusViewModel()
        {
        }

        public GepAdatokTipusViewModel(IGepAdatokTipusService? tipusService, IGepService? gepservice)
        {
            _gepadatoktipusservie = tipusService;
            _gepservice = gepservice;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
            await base.InitializeAsync();
        }

        [RelayCommand]
        private void DoNewGepAdatTipus()
        {
            Selectedtipus = new();
        }

        [RelayCommand]
        private async Task DoDeleteTipus(GepAdatokTipus tipus)
        {
            if (_gepadatoktipusservie is not null)
            {
                ControllerResponse result = await _gepadatoktipusservie.DeleteAsync(tipus.Id);
                if (result.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        private async Task DoSaveTipus(GepAdatokTipus tipus)
        {
            if (_gepadatoktipusservie is not null)
            {
                ControllerResponse response = new();
                if (tipus.HasId)
                {
                    response = await _gepadatoktipusservie.UpdateAsync(tipus);
                }
                else
                {
                    response = await _gepadatoktipusservie.InsertAsync(tipus);
                }
                if (response.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        private async Task GetGepByTipusId()
        {
            if (_gepservice is not null && Selectedtipus is not null && Selectedtipus.HasId)
            {
                List<GepAdatok> GepekWithGepTipusId = await _gepservice.GetGepekByTipusId(Selectedtipus.Id);
                GepekWithGepTipus = new ObservableCollection<GepAdatok>(GepekWithGepTipusId);
            }


        }


        [RelayCommand]
        private async Task MoveGepToWithoutTipus()
        {
            if (_gepservice is not null && SelectedGepekWithGepTipus is not null)
            {
                SelectedGepekWithGepTipus.GepAdatokTipusId = null;
                ControllerResponse result = await _gepservice.UpdateAsync(SelectedGepekWithGepTipus);
                if (result.IsSuccess)
                    await UpdateView();
            }
        }

        [RelayCommand]
        private async Task MoveGepToWithTipus()
        {
            if (_gepservice is not null &&SelectedGepekWithoutTipus is not null&& Selectedtipus is not null)
            {
                SelectedGepekWithoutTipus.GepAdatokTipusId = Selectedtipus.Id;
                ControllerResponse response = await _gepservice.UpdateAsync(SelectedGepekWithoutTipus);
                if (response.IsSuccess)
                    await UpdateView();
            }
        }


        private async Task UpdateView()
        {
            if (_gepadatoktipusservie is not null && _gepservice is not null)
            {
                List<GepAdatokTipus> tipusok = await _gepadatoktipusservie.SelectAllAsync();
                GepadatokTipus = new ObservableCollection<GepAdatokTipus>(tipusok);

                List<GepAdatok> withoutTipusResult =await _gepservice.GetGepekWithoutTipus();
                GepekWithoutTipus = new ObservableCollection<GepAdatok>(withoutTipusResult);
            }
        }
    }
}
