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
    public class JegyTipusService : BaseService<JegyTipus, JegyTipusDto>, IJegyTipusService
    {
        public JegyTipusService(IHttpClientFactory? httpClientFactory, JegyTipusAssambler assambler, JegyAssambler Assambler) : base(httpClientFactory, assambler)
        {
        }


    }
}
