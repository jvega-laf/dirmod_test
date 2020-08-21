using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Interfaces
{
    public interface IServicio
    {
        string Get(string url, Dictionary<string, string> parametros);
    }
}
