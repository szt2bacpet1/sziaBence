using Flyhigh.HttpService.Services;
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
    public class JogosultsagiSzintService : BaseService<JogosultsagiSzints, JogosultsagiSzintsDto>, IJogosultsagiSzintService
    {
        public JogosultsagiSzintService(IHttpClientFactory? httpClientFactory, JogosultsagiSzintAssambler assambler, FelhasznaloAssambler felhasznaloAssambler) : base(httpClientFactory, assambler)
        { 
        }
    }
}
