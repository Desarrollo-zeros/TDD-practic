﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IEntity<T> : IEntity
    {
        T Id { set; get; }
    }
    public interface IEntity
    {

    }
}
