using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Interfaces
{
    public interface IProveedorCotizacion
    {
        double ObtenerCotizacion<T>(string codigo) where T : ICotizacionMoneda;
        double ObtenerCotizacion<T>(T entityType) where T : ICotizacionMoneda;
    }
}
