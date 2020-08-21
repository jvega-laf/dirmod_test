using DirMod_WebApi.Atributos.Base;
using DirMod_WebApi.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Interfaces
{
    public interface ICotizacionMoneda
    {
        string moneda { get; }
        string precio { get; set; }
        string GetCotizacion();
        string GetCodigoCotizacion<T>() where T : CodigoMonedaAttribute;
    }
}
