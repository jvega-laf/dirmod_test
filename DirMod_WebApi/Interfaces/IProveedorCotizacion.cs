using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Interfaces
{
    public interface IProveedorCotizacion
    {
        double ObtenerCotizacion<T>(string codigo) where T : ICotizacionMoneda;
        double ObtenerCotizacion<T>(T entityType) where T : ICotizacionMoneda;
    }
}
