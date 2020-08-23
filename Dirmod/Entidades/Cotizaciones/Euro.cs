using Dirmod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Entidades
{
    [Atributos.CambioTodayMonedaAttribute("EUR")]
    public class Euro: Base.Moneda
    {
        public Euro()
        {
        }
    }

}
