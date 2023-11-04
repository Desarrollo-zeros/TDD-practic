﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IAppDbContext
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
     
    }
}
