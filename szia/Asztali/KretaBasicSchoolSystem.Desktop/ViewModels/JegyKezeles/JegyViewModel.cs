using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flyhigh.Desktop.ViewModels.Base;
using Flyhigh.HttpService.Service;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.JegyKezeles
{
    public partial class JegyViewModel : BaseViewModel
    {

        private readonly IJegyService? _jegyService;
        private readonly IJegyTipusService? _tipusService;


        [ObservableProperty]
        private ObservableCollection<Jegy> _jegy = new();

        [ObservableProperty]
        private ObservableCollection<JegyTipus> _jegytipus = new();


        [ObservableProperty]
        private Jegy _selectedJegy;

        public JegyViewModel()
        {
            _selectedJegy = new Jegy();

        }

        public JegyViewModel(IJegyService? jegySer, IJegyTipusService TipusService)
        {
            SelectedJegy = new Jegy();

            _jegyService = jegySer;
            _tipusService = TipusService;

        }

        [RelayCommand]
        public async Task DoSave(Jegy newJ)
        {
            if (_jegyService is not null)
            {
                ControllerResponse result = new();
                if (newJ.HasId)
                    result = await _jegyService.UpdateAsync(newJ);
                else
                    result = await _jegyService.InsertAsync(newJ);

                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        void DoNew()
        {
            SelectedJegy = new Jegy();
        }

        [RelayCommand]
        public async Task DoDelete(Jegy del)
        {
            if (_jegyService is not null)
            {
                ControllerResponse result = await _jegyService.DeleteAsync(del.Id);
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
            if (_jegyService is not null)
            {
                if (reloadData)
                {
                    List<Jegy> jegyek = await _jegyService.SelectAllIncludedAsync();
                    Jegy = new ObservableCollection<Jegy>(jegyek);
                }
            }
            if (_tipusService is not null)
            {
                if (reloadData)
                {
                    List<JegyTipus> tipusok = await _tipusService.SelectAllAsync();
                    Jegytipus = new ObservableCollection<JegyTipus>(tipusok);
                }
            }
        }
    }
}

