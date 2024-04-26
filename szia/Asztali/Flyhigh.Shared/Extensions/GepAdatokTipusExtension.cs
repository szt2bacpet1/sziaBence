using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class GepAdatokTipusExtension
    {
        public static GepAdatokTipusDto ToDto(this GepAdatokTipus tipusok)
        {
            return new GepAdatokTipusDto
            {
                Id = tipusok.Id,
                Gepadattipus = tipusok.Gepadattipus,
                Gepek = tipusok.GepekTipus,
            };
        }

        public static GepAdatokTipus ToModel(this GepAdatokTipusDto model)
        {
            return new GepAdatokTipus
            {
                Id = model.Id,
                Gepadattipus = model.Gepadattipus,
                GepekTipus = model.Gepek,
            };
        }



    }
}
