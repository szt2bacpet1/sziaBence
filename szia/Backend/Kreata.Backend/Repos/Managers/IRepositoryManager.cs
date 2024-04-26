using Flyhigh.Backend.Repos.SwitchTables;

namespace Flyhigh.Backend.Repos.Managers
{
    public interface IRepositoryManager
    {
        public ICountriesRepo? Countries { get; }
        public ICountryTypeOfRepo? CountryTypeOfRepo { get; }
        public IFelhasznaloRepo? FelhasznaloRepo { get; }
        public IGepRepo? GepRepo { get; }
        public IGepAdatokTipusRepo? GepAdatokTipusRepo { get; }
        public IJegyRepo? JegyRepo { get; }
        public IJegyTipusRepo? JegyTipusRepo { get; }
        public IJogosultsagiSzintsRepo? JogosultsagiSzintsRepo { get; }
    }
}
