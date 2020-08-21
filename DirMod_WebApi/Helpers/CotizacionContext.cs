using DirMod_WebApi.Entidades.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Helpers
{
    public class CotizacionContext
    {
        private Interfaces.ICotizacion Cotizacion;
        private Interfaces.ICotizadorAPI Cotizador;

        public CotizacionContext(Interfaces.ICotizacion cotizacion, Interfaces.ICotizadorAPI cotizador)
        {
            this.Cotizacion = cotizacion;
            this.Cotizador = cotizador;
        }

        public string GetCotizacion()
        {
            var result = Cotizador.ObtenerCotizacion(Cotizacion);
            Cotizacion.precio = result.ToString(CultureInfo.CurrentUICulture);
            
            return Cotizacion.GetCotizacion();
        }
    }

}
