using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Interfaces
{
    public interface IServicioConexion
    {
        string Get(string url, Dictionary<string, string> parametros);
    }
}
