using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Desktop.ViewModels.Legijaratok
{
    public static class RepulotarsasagViewModelExtension
    {
        public static RepulotarsasagQueryParameters ToReptarsQueryParameters(this RepulotarsasagViewModel reptarsAdatokViewModel)
        {
            return new RepulotarsasagQueryParameters
            {
                Name = reptarsAdatokViewModel.SearchedName
            };

        }
    }
}
