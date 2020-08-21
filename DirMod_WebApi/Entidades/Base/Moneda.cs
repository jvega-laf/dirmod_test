using DirMod_WebApi.Atributos.Base;
using DirMod_WebApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Entidades.Base
{
    public abstract class Moneda : ICotizacionMoneda
    {
        private string _moneda = "";
        public string moneda { get { return _moneda; } }
        public string precio { get; set; } = (0d).ToString();

        public Moneda()
        {
            _moneda = this.GetType().Name.ToLower();
        }

        public virtual string GetCotizacion()
        {
            var moneda = (Entidades.Base.Moneda)this;
            return JsonConvert.SerializeObject(moneda, Formatting.Indented);
        }

        public string GetCodigoCotizacion<T>() where T : CodigoMonedaAttribute
        {
            string codigo = "";
            try
            {
                /*Obtengo los atributos seteados a la Clase*/
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(this.GetType());

                /*Busco el Atributo del Tipo solicitado*/
                var attr = attrs?.FirstOrDefault(r => r.GetType() == typeof(T));
                if (attr == null)
                    throw new Exception(string.Format("El atributo {0} no está definido.", this.GetType().Name));

                /*Obtengo el código de moneda*/
                codigo = ((T)attr).CodigoMoneda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigo;
        }
    }
}
