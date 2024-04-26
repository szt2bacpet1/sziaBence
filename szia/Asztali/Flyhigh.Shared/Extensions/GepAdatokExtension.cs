using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class GepAdatokExtension
    {
        public static GepAdatokDto ToGepAdatokDto(this GepAdatok gepek)
        {
            return new GepAdatokDto
            {
                Id = gepek.Id,
                GepAdatokTipusId = gepek.GepAdatokTipusId,
                Gepneve = gepek.Gepneve,
                Foglaltturista = gepek.Foglaltturista,
                Foglalt1oszt = gepek.Foglalt1oszt,
                Elsoosztulohelyek = gepek.Elsoosztulohelyek,
                Turistaulohelyek = gepek.Turistaulohelyek,
                Fajta = gepek.Fajta,
                GepAdatokTipus = gepek.GepAdatokTipus
                
            };
        }
        public static GepAdatok ToGepAdatok(this GepAdatokDto gepekdto)
        {
            return new GepAdatok
            {
                Id = gepekdto.Id,
                GepAdatokTipusId = gepekdto.GepAdatokTipusId,
                Gepneve = gepekdto.Gepneve,
                Foglaltturista = gepekdto.Foglaltturista,
                Foglalt1oszt = gepekdto.Foglalt1oszt,
                Elsoosztulohelyek = gepekdto.Elsoosztulohelyek,
                Turistaulohelyek = gepekdto.Turistaulohelyek,
                Fajta = gepekdto.Fajta,
                GepAdatokTipus = gepekdto.GepAdatokTipus

            };
        }
    }
}
