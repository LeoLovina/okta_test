﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Services
{
    public interface IApiService
    {
        Task<IList<string>> GetValues();
    }
}
