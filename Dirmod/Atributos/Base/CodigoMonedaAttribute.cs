using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Atributos.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class CodigoMonedaAttribute : Attribute
    {
        public string CodigoMoneda { get; set; } = "";

        public CodigoMonedaAttribute(string codigoMoneda)
        {
            CodigoMoneda = codigoMoneda;
        }
    }
}
