using DirMod_WebApi.Atributos.Base;
using DirMod_WebApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Entidades.Base
{
    public abstract class Moneda : ICotizacion
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

        public string GetCodigoCotizacion<T>() where T : CodigoCotizacionAttribute
        {
            string codigo = "";
            try
            {

                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(this.GetType());

                var attr = attrs?.FirstOrDefault(r => r.GetType() == typeof(T));
                if (attr == null)
                    throw new Exception(string.Format("El atributo {0} no está definido.", this.GetType().Name));

                codigo = ((T)attr).CodigoCotizacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigo;
        }
    }
}
