using Flyhigh.HttpService.Service;
using Flyhigh.Shared.Assamblers;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.HttpService.Service
{
    
    public class GepAdatokTipusService : BaseService<GepAdatokTipus, GepAdatokTipusDto>, IGepAdatokTipusService
    {
        public GepAdatokTipusService(IHttpClientFactory? httpClientFactory, GepAdatokTipusAssambler assambler, GepAdatokAssambler gepAssambler) : base(httpClientFactory, assambler)
        {
        }
    }
}
