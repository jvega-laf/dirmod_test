using DirMod_WebApi.Atributos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirMod_WebApi.Helpers
{
    public static class Extensiones
    {
        //public static string GetCodigoCotizacion<T>(this Interfaces.ICotizacion moneda) where T : CodigoCotizacionAttribute
        //{
        //    string codigo = "";
        //    try
        //    {
        //        var t = moneda.GetType();
        //        T entAttr = Activator.CreateInstance<T>();

        //        System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

        //        var attr = attrs?.FirstOrDefault(r => r.GetType() is T);
        //        if (attr == null)
        //            throw new Exception(string.Format("El atributo {0} no está definido.", entAttr.GetType().Name));

        //        codigo = ((CodigoCotizacionAttribute)attr).CodigoCotizacion;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigo;
        //}
    }
}
