using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class JegyTipusExtension
    {
        public static JegyTipusDto ToDto(this JegyTipus tipusok)
        {
            return new JegyTipusDto
            {
                Id = tipusok.Id,
                Jegytipus = tipusok.Jegytipus,
                JegyTipusok = tipusok.JegyTipusok,
            };
        }

        public static JegyTipus ToModel(this JegyTipusDto model)
        {
            return new JegyTipus
            {
                Id = model.Id,
                Jegytipus = model.Jegytipus,
                JegyTipusok = model.JegyTipusok,
            };
        }


    }
}
