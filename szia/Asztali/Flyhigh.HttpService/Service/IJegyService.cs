﻿using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.HttpService.Service
{
    public interface IJegyService : IBaseService<Jegy>
    {
        public Task<List<Jegy>> SelectAllIncludedAsync();


    }
}
