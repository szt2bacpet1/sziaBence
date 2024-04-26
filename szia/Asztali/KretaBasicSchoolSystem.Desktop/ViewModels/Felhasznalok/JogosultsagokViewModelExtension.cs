using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flyhigh.Desktop.ViewModels.Legijaratok;

namespace Flyhigh.Desktop.ViewModels.Felhasznalok
{
    public static class JogosultsagokViewModelExtension
    {
        public static FelhasznaloQueryParameters ToFelhasznaloQueryParameters(this JogosultsagokViewModel felhasznaloViewModel)
        {
            return new FelhasznaloQueryParameters
            {
                Name = felhasznaloViewModel.SearchedName
            };
        }
    }
}