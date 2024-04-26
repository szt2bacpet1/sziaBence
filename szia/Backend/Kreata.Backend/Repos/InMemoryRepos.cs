using Flyhigh.Backend.Context;
using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public class GepAdatokInMemoryRepo : GepRepo<FlyhighInMemoryContext>
    {
        public GepAdatokInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

    public class GepAdatokTipusInMemoryRepo : GepAdatokTipusRepo<FlyhighInMemoryContext>
    {
        public GepAdatokTipusInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

    public class FelhasznaloInMemoryRepo : FelhasznaloRepo<FlyhighInMemoryContext>
    {
        public FelhasznaloInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
    public class JogosultsagiSzintInMemoryRepo : JogosultsagiSzintsRepo<FlyhighInMemoryContext>
    {
        public JogosultsagiSzintInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

    public class RepuloInMemoryRepo : RepulotarsRepo<FlyhighInMemoryContext>
    {
        public RepuloInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
    public class CountryInMemoryRepo : CountriesRepo<FlyhighInMemoryContext>
    {
        public CountryInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

    public class JegyInMemoryRepo : JegyRepo<FlyhighInMemoryContext>
    {
        public JegyInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

    public class JegyTipusInMemoryRepo : JegyTipusRepo<FlyhighInMemoryContext>
    {
        public JegyTipusInMemoryRepo(IDbContextFactory<FlyhighInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

}