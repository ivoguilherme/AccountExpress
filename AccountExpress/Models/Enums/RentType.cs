using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models.Enums
{
    public enum RentType
    {
        Normal,
        [Description("Promocional (10%)")]
        Promocional,
        [Description("Cliente Novo (15%)")]
        ClienteNovo
    }
}
