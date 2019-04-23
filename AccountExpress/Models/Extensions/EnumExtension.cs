using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models.Extensions
{
    public static class EnumExtension
    {
        public static string ObterDescricao(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
