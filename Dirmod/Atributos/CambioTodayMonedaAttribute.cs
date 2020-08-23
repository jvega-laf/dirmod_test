using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Atributos
{
    public class CambioTodayMonedaAttribute : Base.CodigoMonedaAttribute
    {
        public CambioTodayMonedaAttribute(string codigoCotizacion) : base(codigoCotizacion)
        {
            CodigoMoneda = codigoCotizacion;
        }
    }
}
