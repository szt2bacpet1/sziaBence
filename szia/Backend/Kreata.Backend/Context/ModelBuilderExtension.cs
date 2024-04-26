using Flyhigh.Shared.Enums;
using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Flyhigh.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid JogosultsagiSzint1 = Guid.NewGuid(); //administrator
            Guid JogosultsagiSzint2 = Guid.NewGuid(); //ugyfel
            List<JogosultsagiSzints> jogosultsagiSzint = new()
            {
                new JogosultsagiSzints
                {
                        Id=JogosultsagiSzint1,
                        JogosultsagiSzint="Adminisztrátor",
                },
                new JogosultsagiSzints
                {
                    Id=JogosultsagiSzint2,
                    JogosultsagiSzint="Ügyfél",
                }
            };
            List<Felhasznalo> felhasznalok = new()
            {
                new Felhasznalo
                {
                    Id=Guid.NewGuid(),
                    FirstName="János",
                    LastName="Jegy",
                    BirthsDay=new DateTime(2022,10,10),
                    JogosultsagiSzintId=JogosultsagiSzint1,
                },
                new Felhasznalo
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    BirthsDay=new DateTime(2021,4,4),
                    JogosultsagiSzintId=JogosultsagiSzint2,
                }
            };
            Guid TipusId1 = Guid.NewGuid(); //utasszallito
            Guid TipusId2 = Guid.NewGuid(); //tehergep

            List<GepAdatokTipus> gepadatoktipus = new()
            {
                new GepAdatokTipus
                {
                    Id=TipusId1,
                    Gepadattipus = "Utasszállító",
                },
                new GepAdatokTipus
                {
                    Id=TipusId2,
                    Gepadattipus = "Tehergép",
                }
            };
            List<GepAdatok> gepek = new()
            {
                new GepAdatok
                {
                    Id=Guid.NewGuid(),
                    Gepneve="B-550",
                    Foglaltturista=23,
                    Foglalt1oszt=43,
                    Elsoosztulohelyek=7,
                    Turistaulohelyek = 45,
                    GepAdatokTipusId = TipusId1,
                },
                new GepAdatok
                {
                    Id=Guid.NewGuid(),
                    Gepneve="ZF-870",
                    Foglaltturista=0,
                    Foglalt1oszt=0,
                    Elsoosztulohelyek=0,
                    Turistaulohelyek = 0,
                    GepAdatokTipusId = TipusId2,
                },
                new GepAdatok
                {
                    Id=Guid.NewGuid(),
                    Gepneve="RTG-820",
                    Foglaltturista=54,
                    Foglalt1oszt=84,
                    Elsoosztulohelyek=12,
                    Turistaulohelyek = 13,
                    GepAdatokTipusId = TipusId1,
                },
                new GepAdatok
                {
                    Id=Guid.NewGuid(),
                    Gepneve="M-900",
                    Foglaltturista=32,
                    Foglalt1oszt=76,
                    Elsoosztulohelyek=12,
                    Turistaulohelyek = 23,
                    GepAdatokTipusId = TipusId1
                },
                 new GepAdatok
                {
                    Id=Guid.NewGuid(),
                    Gepneve="BZ-570",
                    Foglaltturista=0,
                    Foglalt1oszt=0,
                    Elsoosztulohelyek=0,
                    Turistaulohelyek = 0,
                    GepAdatokTipusId = TipusId2,
                },
                new GepAdatok
                {
                    Id=Guid.NewGuid(),
                    Gepneve="BencePrivat-1",
                    Foglaltturista=0,
                    Foglalt1oszt=0,
                    Elsoosztulohelyek=0,
                    Turistaulohelyek = 0,
                    GepAdatokTipusId = null,
                },
            };

            //Jegykezelés
            Guid business = Guid.NewGuid();
            Guid economy = Guid.NewGuid();

            List<JegyTipus> jegytipus = new()
            {
                new JegyTipus
                {
                    Id=business,
                    Jegytipus = "business",
                },
                new JegyTipus
                {
                    Id=economy,
                    Jegytipus = "economy",
                }
            };


            List<Jegy> jegyek = new()
            {
                new Jegy
                {
                    Id=Guid.NewGuid(),
                    Megrendelo_nev="admin",
                    Indulas_hely="Csehország",
                    Erkezes_hely="Ausztria",
                    Indulasido="14:45",
                    Erkezesido = "16:45",
                    Utazok = 2,
                    Osztaly = "business",
                    Ar = 19779,
                    SorSzek = "1, 8, 1",
                    JegyId = business
                },
                new Jegy
                {
                    Id=Guid.NewGuid(),
                    Megrendelo_nev="asd",
                    Indulas_hely="Belgium",
                    Erkezes_hely="Ciprus",
                    Indulasido="15:40",
                    Erkezesido = "17:40",
                    Utazok = 2,
                    Osztaly = "business",
                    Ar = 23111,
                    SorSzek = "1, 18, 1;1, 17, 1",
                    JegyId = business

                },
                new Jegy
                {

                    Id=Guid.NewGuid(),
                    Megrendelo_nev="asd",
                    Indulas_hely="Belgium",
                    Erkezes_hely="Ciprus",
                    Indulasido="14:45",
                    Erkezesido = "16:45",
                    Utazok = 3,
                    Osztaly = "business",
                    Ar = 65108,
                    SorSzek = "1, 21, 1;1, 20, 1;1, 19, 1",
                    JegyId = business

                },
                new Jegy
                {

                    Id=Guid.NewGuid(),
                    Megrendelo_nev="teszter",
                    Indulas_hely="Csehország",
                    Erkezes_hely="Ausztria",
                    Indulasido="14:45",
                    Erkezesido = "16:45",
                    Utazok = 5,
                    Osztaly = "business",
                    Ar = 98624,
                    SorSzek = "1, 1, 1;1, 2, 1;1, 3, 1;1, 5, 1;1, 4, 1",
                    JegyId = economy
                }
            };


            #region COUNTRY_ID
            Guid countryId1 = Guid.NewGuid();
            Guid countryId2 = Guid.NewGuid();
            Guid countryId3 = Guid.NewGuid();
            Guid countryId4 = Guid.NewGuid();
            Guid countryId5 = Guid.NewGuid();
            Guid countryId6 = Guid.NewGuid();
            Guid countryId7 = Guid.NewGuid();
            Guid countryId8 = Guid.NewGuid();
            Guid countryId9 = Guid.NewGuid();
            Guid countryId10 = Guid.NewGuid();
            Guid countryId11 = Guid.NewGuid();
            Guid countryId12 = Guid.NewGuid();
            Guid countryId13 = Guid.NewGuid();
            Guid countryId14 = Guid.NewGuid();
            Guid countryId15 = Guid.NewGuid();
            Guid countryId16 = Guid.NewGuid();
            Guid countryId17 = Guid.NewGuid();
            Guid countryId18 = Guid.NewGuid();
            Guid countryId19 = Guid.NewGuid();
            Guid countryId20 = Guid.NewGuid();
            #endregion
            #region Repülőtársaság
            List<Repulotarsasag> reptars = new List<Repulotarsasag>
                {
                    new Repulotarsasag
                    {
                        Id=Guid.NewGuid(),
                        CountryId=countryId1,
                        LastName="American Airlines",
                        BirthsDay=new DateTime(1926,04,15),
                        Country = "USA"
                    },
                    new Repulotarsasag
                    {
                        Id=Guid.NewGuid(),
                        CountryId=countryId2,
                        LastName="airBaltic",
                        BirthsDay=new DateTime(1995,08,28),
                        Country = "Latvia"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId3,
                        LastName = "British Airways",
                        BirthsDay = new DateTime(1974, 4, 1),
                        Country = "United Kingdom"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId4,
                        LastName = "Lufthansa",
                        BirthsDay = new DateTime(1953, 1, 6),
                        Country = "Germany"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId5,
                        LastName = "Air France",
                        BirthsDay = new DateTime(1933, 10, 7),
                        Country = "France"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId6,
                        LastName = "KLM Royal Dutch Airlines",
                        BirthsDay = new DateTime(1919, 10, 7),
                        Country = "Netherlands"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId7,
                        LastName = "Swiss International Air Lines",
                        BirthsDay = new DateTime(2002, 4, 1),
                        Country = "Switzerland"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId8,
                        LastName = "Aeroflot",
                        BirthsDay = new DateTime(1923, 3, 17),
                        Country = "Russia"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId9,
                        LastName = "SAS Scandinavian Airlines",
                        BirthsDay = new DateTime(1946, 8, 1),
                        Country = "Sweden"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId10,
                        LastName = "Finnair",
                        BirthsDay = new DateTime(1923, 11, 1),
                        Country = "Finland"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId11,
                        LastName = "Austrian Airlines",
                        BirthsDay = new DateTime(1957, 9, 30),
                        Country = "Austria"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId12,
                        LastName = "Norwegian Air Shuttle",
                        BirthsDay = new DateTime(1993, 1, 22),
                        Country = "Norway"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId13,
                        LastName = "LOT Polish Airlines",
                        BirthsDay = new DateTime(1929, 1, 1),
                        Country = "Poland"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId14,
                        LastName = "Turkish Airlines",
                        BirthsDay = new DateTime(1933, 5, 20),
                        Country = "Turkey"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId15,
                        LastName = "Iberia",
                        BirthsDay = new DateTime(1927, 6, 28),
                        Country = "Spain"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId16,
                        LastName = "Aegean Airlines",
                        BirthsDay = new DateTime(1987, 5, 28),
                        Country = "Greece"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId17,
                        LastName = "Czech Airlines",
                        BirthsDay = new DateTime(1923, 10, 6),
                        Country = "Czech Republic"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId18,
                        LastName = "Alitalia",
                        BirthsDay = new DateTime(1946, 9, 16),
                        Country = "Italy"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId19,
                        LastName = "Brussels Airlines",
                        BirthsDay = new DateTime(2006, 3, 25),
                        Country = "Belgium"
                    },
                    new Repulotarsasag
                    {
                        Id = Guid.NewGuid(),
                        CountryId=countryId20,
                        LastName = "Wizz Air",
                        BirthsDay = new DateTime(2003, 9, 19),
                        Country = "Hungary"
                    },
                };
            List<Countries> countries = new List<Countries>
                {
                    new Countries
                    {
                        Id = countryId1,
                        CountryName="USA",
                    },
                    new Countries
                    {
                        Id = countryId2,
                        CountryName="Latvia",
                    },
                    new Countries
                    {
                        Id = countryId3,
                        CountryName="United Kingdom",
                    },
                    new Countries
                    {
                        Id = countryId4,
                        CountryName="Germany",
                    },
                    new Countries
                    {
                        Id = countryId5,
                        CountryName="France",
                    },
                    new Countries
                    {
                        Id = countryId6,
                        CountryName="Netherlands",
                    },
                    new Countries
                    {
                        Id = countryId7,
                        CountryName="Switzerland",
                    },
                    new Countries
                    {
                        Id = countryId8,
                        CountryName="Russia",
                    },
                    new Countries
                    {
                        Id = countryId9,
                        CountryName="Sweden",
                    },
                    new Countries
                    {
                        Id = countryId10,
                        CountryName="Finland",
                    },
                    new Countries
                    {
                        Id = countryId11,
                        CountryName="Austria",
                    },
                    new Countries
                    {
                        Id = countryId12,
                        CountryName="Norway",
                    },
                    new Countries
                    {
                        Id = countryId13,
                        CountryName="Poland",
                    },
                    new Countries
                    {
                        Id = countryId14,
                        CountryName="Turkey",
                    },
                    new Countries
                    {
                        Id = countryId15,
                        CountryName="Spain",
                    },
                    new Countries
                    {
                        Id = countryId16,
                        CountryName="Greece",
                    },
                    new Countries
                    {
                        Id = countryId17,
                        CountryName="Czech Republic",
                    },
                    new Countries
                    {
                        Id = countryId18,
                        CountryName="Italy",
                    },
                    new Countries
                    {
                        Id = countryId19,
                        CountryName="Belgium",
                    },
                    new Countries
                    {
                        Id = countryId20,
                        CountryName="Hungary",
                    }
                };
            #endregion

            // Felhasznalok
            modelBuilder.Entity<Felhasznalo>().HasData(felhasznalok);
            // EducationLevel
            modelBuilder.Entity<JogosultsagiSzints>().HasData(jogosultsagiSzint);
            // GépAdatok
            modelBuilder.Entity<GepAdatok>().HasData(gepek);
            //Gép tipusok
            modelBuilder.Entity<GepAdatokTipus>().HasData(gepadatoktipus);
            // Repülőtársaságok
            modelBuilder.Entity<Repulotarsasag>().HasData(reptars);
            // Országok
            modelBuilder.Entity<Countries>().HasData(countries);
            //Jegyek
            modelBuilder.Entity<Jegy>().HasData(jegyek);

            modelBuilder.Entity<JegyTipus>().HasData(jegytipus);

        }
    }
}