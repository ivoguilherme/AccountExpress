using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models.Enums
{
    public enum VehicleExchange
    {
        Manual,
        Automático,
        [Description("Dupla Embreagem")]
        DuplaEmbreagem,
        CVT
    }
}
