using Dirmod.Atributos.Base;
using Dirmod.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Interfaces
{
    public interface ICotizacionMoneda
    {
        string moneda { get; }
        string precio { get; set; }
        ICotizacionMoneda GetCotizacion();
        string GetCodigoCotizacion<T>() where T : CodigoMonedaAttribute;
    }
}
