using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Interfaces
{
    public interface ICotizadorAPI
    {
        double ObtenerCotizacion<T>(string codigo) where T : ICotizacion;
        double ObtenerCotizacion<T>(T entityType) where T : ICotizacion;
    }
}
