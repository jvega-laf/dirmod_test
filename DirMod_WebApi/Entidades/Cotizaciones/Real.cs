using DirMod_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Entidades
{
    [Atributos.CambioTodayMonedaAttribute("BRL")]
    public class Real : Base.Moneda
    {
        public Real()
        {
        }
    }
}
