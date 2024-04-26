using Flyhigh.Backend.Repos.SwitchTables;

namespace Flyhigh.Backend.Repos.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private ICountriesRepo? _countriesRepo;
        private ICountryTypeOfRepo? _countryTypeOfRepo;
        private IFelhasznaloRepo? _felhasznaloRepo;
        private IGepRepo? _gepRepo;
        private IGepAdatokTipusRepo? _gepAdatokTipusRepo;
        private IJegyRepo? _jegyRepo;
        private IJegyTipusRepo? _jegyTipusRepo;
        private IJogosultsagiSzintsRepo? _jogosultsagiSzintsRepo;
    
    public RepositoryManager(
        private ICountriesRepo? countriesRepo,
        private ICountryTypeOfRepo? countryTypeOfRepo,
        private IFelhasznaloRepo? felhasznaloRepo,
        private IGepRepo? gepRepo,
        private IGepAdatokTipusRepo? gepAdatokTipusRepo,
        private IJegyRepo? jegyRepo,
        private IJegyTipusRepo? jegyTipusRepo,
        private IJogosultsagiSzintsRepo? jogosultsagiSzintsRepo,
        )
        {
        
        _countriesRepo=countriesRepo;
        _countryTypeOfRepo= countryTypeOfRepo ;
        _felhasznaloRepo=  felhasznaloRepo;
        _gepRepo = gepRepo ;
        _gepAdatokTipusRepo= gepAdatokTipusRepo ;
        _jegyRepo= jegyRepo ;
        _jegyTipusRepo= jegyTipusRepo ;
        _jogosultsagiSzintsRepo= jogosultsagiSzintsRepo ;
    }
    public ICountriesRepo? Countries=> countriesRepo;
    public ICountryTypeOfRepo? CountryTypeOfRepo=> countryTypeOfRepo;
    public IFelhasznaloRepo? FelhasznaloRepo => felhasznaloRepo;
    public IGepRepo? GepRepo=>gepRepo;
    public IGepAdatokTipusRepo? GepAdatokTipusRepo=> gepAdatokTipusRepo;
    public IJegyRepo? JegyRepo=> jegyRepo;
    public IJegyTipusRepo? JegyTipusRepo=> jegyTipusRepo;
    public IJogosultsagiSzintsRepo? JogosultsagiSzintsRepo=> jogosultsagiSzintsRepo;
}

    

