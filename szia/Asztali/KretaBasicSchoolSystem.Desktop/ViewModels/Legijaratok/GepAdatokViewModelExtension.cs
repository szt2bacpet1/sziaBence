using Flyhigh.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.Legijaratok
{
    public static class GepAdatokViewModelExtension
    {
        public static GepAdatokQueryParameters ToGepQueryParameters(this GepAdatokViewModel gepAdatokViewModel)
        {
            return new GepAdatokQueryParameters
            {
                MinFoglaltTurista = gepAdatokViewModel.FilteredMinTurista,
                MaxFoglaltTurista = gepAdatokViewModel.FilteredMaxTurista,
                Name = gepAdatokViewModel.SearchedName
            };
        
        }

    }
}
