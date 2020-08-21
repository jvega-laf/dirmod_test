using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirMod_WebApi.Atributos;
using DirMod_WebApi.Entidades.Cotizador;
using DirMod_WebApi.Interfaces;
using Newtonsoft.Json;

namespace DirMod_WebApi.Helpers
{
    public class CambioTodayCotizador : Interfaces.ICotizadorAPI
    {
        private const string key = "4831|pfdjNOxShSk4VxoPvujQUmiPtDv6H1gc";
        private const string url = "https://api.cambio.today/v1/quotes/{0}/{1}/json";
        private const string monedaConversion = "ARS";
        private const string quantity = "1";
        private IServicio Servicio { get; set; } = null;

        public CambioTodayCotizador(IServicio servicio)
        {
            Servicio = servicio;
            if (servicio == null)
                throw new NullReferenceException("El servicio pasado cómo parametro no puede ser nulo.");
        }

        public double ObtenerCotizacion<T>(T entityType) where T : ICotizacion
        {
            var codigo = entityType.GetCodigoCotizacion<CambioTodayAttribute>();
            return ObtenerCotizacion<T>(codigo);
        }
        public double ObtenerCotizacion<T>(string codigo) where T : ICotizacion
        {
            double ret = 0d;
            try
            {
                var parametros = new Dictionary<string, string> { };
                parametros.Add(nameof(CambioTodayCotizador.quantity), CambioTodayCotizador.quantity);
                parametros.Add(nameof(CambioTodayCotizador.key), CambioTodayCotizador.key);
                if (!string.IsNullOrEmpty(codigo) && !string.IsNullOrWhiteSpace(codigo))
                {
                    var urlFinal = string.Format(url, codigo, CambioTodayCotizador.monedaConversion);
                    var content = Servicio.Get(urlFinal, parametros);
                    var result = JsonConvert.DeserializeObject<CambioTodayCotizadorResponse>(content);

                    ret = result == null || result.result == null ? 0d : result.result.value;

                }
                else
                    throw new Exception("La entidad no tiene asignado un código de moneda.");

                return Math.Round(ret, 2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
