using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DirMod_WebApi.Controllers
{
    [Route("cotizacion/[controller]")]
    [ApiController]
    public class EuroController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var context = new Helpers.CotizacionContext(
                    new Entidades.Euro(), 
                    new Helpers.CambioTodayCotizador(new Helpers.HttpCliente())
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
