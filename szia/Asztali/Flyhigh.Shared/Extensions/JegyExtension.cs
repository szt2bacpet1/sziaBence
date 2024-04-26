using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class JegyExtension
    {

        public static JegyDto ToJegyDto(this Jegy jegy)
        {
            return new JegyDto
            {
                Id = jegy.Id,
                Megrendelo_nev = jegy.Megrendelo_nev,
                Indulas_hely = jegy.Indulas_hely,
                Erkezes_hely = jegy.Erkezes_hely,
                Indulasido = jegy.Indulasido,
                Erkezesido = jegy.Erkezesido,
                Osztaly = jegy.Osztaly,
                Utazok = jegy.Utazok,
                Ar = jegy.Ar,
                SorSzek = jegy.SorSzek,
                JegyId = jegy.JegyId

        };
        }
        public static Jegy ToJegy(this JegyDto jegydto)
        {
            return new Jegy
            {
                Id = jegydto.Id,
                Megrendelo_nev = jegydto.Megrendelo_nev,
                Indulas_hely = jegydto.Indulas_hely,
                Erkezes_hely = jegydto.Erkezes_hely,
                Indulasido = jegydto.Indulasido,
                Erkezesido = jegydto.Erkezesido,
                Osztaly = jegydto.Osztaly,
                Utazok = jegydto.Utazok,
                Ar = jegydto.Ar,
                SorSzek = jegydto.SorSzek,
                JegyId = jegydto.JegyId

            };
        }


    }
}
