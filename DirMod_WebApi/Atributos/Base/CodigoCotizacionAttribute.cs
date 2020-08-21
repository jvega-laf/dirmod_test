using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Atributos.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class CodigoCotizacionAttribute : Attribute
    {
        public string CodigoCotizacion { get; set; } = "";

        public CodigoCotizacionAttribute(string codigoCotizacion)
        {
            CodigoCotizacion = codigoCotizacion;
        }
    }
}
