﻿using AccountExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Interfaces.Services
{
    public interface ICarRent
    {
        double Calculate(Rent rent);
    }
}
