using DirMod_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Entidades
{
    [Atributos.CambioTodayAttribute("EUR")]
    public class Euro: Base.Moneda
    {
        public Euro()
        {
        }
    }

}
