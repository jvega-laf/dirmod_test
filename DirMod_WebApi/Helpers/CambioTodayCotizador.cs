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
    public class CambioTodayCotizador : Interfaces.IProveedorCotizacion
    {
        #region Constantes

        private const string key = "4831|pfdjNOxShSk4VxoPvujQUmiPtDv6H1gc";
        private const string url = "https://api.cambio.today/v1/quotes/{0}/{1}/json";
        private const string monedaConversion = "ARS";
        private const string quantity = "1";

        #endregion

        #region Propiedades Privadas

        private IServicioConexion ServicioConexion { get; set; } = null;

        #endregion

        #region Contructor

        public CambioTodayCotizador(IServicioConexion conexion)
        {
            ServicioConexion = conexion;
            if (conexion == null)
                throw new NullReferenceException("El servicio pasado cómo parametro no puede ser nulo.");
        }

        #endregion

        #region Metodos Publicos

        public double ObtenerCotizacion<T>(T entityType) where T : ICotizacionMoneda
        {
            var codigo = entityType.GetCodigoCotizacion<CambioTodayMonedaAttribute>();
            return ObtenerCotizacion<T>(codigo);
        }

        public double ObtenerCotizacion<T>(string codigo) where T : ICotizacionMoneda
        {
            double ret = 0d;
            try
            {
                /*Creo los parámetros*/
                var parametros = new Dictionary<string, string> { };
                parametros.Add(nameof(CambioTodayCotizador.quantity), CambioTodayCotizador.quantity);
                parametros.Add(nameof(CambioTodayCotizador.key), CambioTodayCotizador.key);

                /*Verifico que el código no sea nulo, vacio o espacios*/
                if (!string.IsNullOrEmpty(codigo) && !string.IsNullOrWhiteSpace(codigo))
                {
                    /*Creo la url aplicando un format para reemplazar moneda cotización y moneda destino en constante */
                    var urlFinal = string.Format(url, codigo, CambioTodayCotizador.monedaConversion);
                    /*Hago la consulta al proveedor por medio del servicio y obtengo el resultado*/
                    var content = ServicioConexion.Get(urlFinal, parametros);
                    /*Deserializo la respuesta en formato Json al Tipo de respuesta*/
                    var result = JsonConvert.DeserializeObject<CambioTodayCotizadorResponse>(content);
                    /*Seteo el resultado*/
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

        #endregion
    }
}
