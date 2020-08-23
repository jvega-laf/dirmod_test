using Dirmod.Entidades.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Helpers
{
    public class CotizacionContext
    {
        private Interfaces.ICotizacionMoneda Cotizacion;
        private Interfaces.IProveedorCotizacion Cotizador;

        public CotizacionContext(Interfaces.ICotizacionMoneda cotizacion, Interfaces.IProveedorCotizacion cotizador)
        {
            this.Cotizacion = cotizacion;
            this.Cotizador = cotizador;
        }

        public Moneda GetCotizacion()
        {
            /*Obtengo la cotización*/
            var result = Cotizador.ObtenerCotizacion(Cotizacion);
            /*Convierto el resultado de Double a String*/
            Cotizacion.precio = result.ToString(CultureInfo.CurrentUICulture);
            
            return (Moneda)Cotizacion.GetCotizacion();
        }
    }

}
