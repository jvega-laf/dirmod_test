using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dirmod.Entidades.Base;

namespace Dirmod.Controllers
{
    [Produces("application/json")]
    [Route("/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {

        [HttpGet("[action]")]
        public IEnumerable<Moneda> GetCotizaciones()
        {
            List<Moneda> monedas = new List<Moneda> { };
            try
            {
                var moneda = Dolar();
                if (moneda != null)
                    monedas.Add(moneda);

                moneda = Euro();
                if (moneda != null)
                    monedas.Add(moneda);

                moneda = Real();
                if (moneda != null)
                    monedas.Add(moneda);

                return monedas;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("[action]")]
        public Moneda Dolar()
        {
            try
            {
                var context = new Dirmod.Helpers.CotizacionContext(
                    new Dirmod.Entidades.Dolar(),
                    new Dirmod.Helpers.CambioTodayCotizador(new Dirmod.Helpers.HttpCliente())
                    );

                var cotizacion = context.GetCotizacion();
                return cotizacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("[action]")]
        public Moneda Euro()
        {
            try
            {
                var context = new Dirmod.Helpers.CotizacionContext(
                    new Dirmod.Entidades.Euro(),
                    new Dirmod.Helpers.CambioTodayCotizador(new Dirmod.Helpers.HttpCliente())
                    );

                var cotizacion = context.GetCotizacion();
                return cotizacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("[action]")]
        public Moneda Real()
        {
            try
            {
                var context = new Dirmod.Helpers.CotizacionContext(
                    new Dirmod.Entidades.Real(),
                    new Dirmod.Helpers.CambioTodayCotizador(new Dirmod.Helpers.HttpCliente())
                    );

                var cotizacion = context.GetCotizacion();
                return cotizacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }


}