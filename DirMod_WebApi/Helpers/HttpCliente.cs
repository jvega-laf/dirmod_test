using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DirMod_WebApi.Helpers
{
    internal class HttpCliente : Interfaces.IServicioConexion
    {
        private static string ConcatParams(Dictionary<string,string> parameters)
        {
            bool FirstParam = true;
            StringBuilder Parametros = null;

            if (parameters != null)
            {
                Parametros = new StringBuilder();
                foreach (var param in parameters)
                {
                    Parametros.Append(FirstParam ? "" : "&");
                    Parametros.Append(param.Key + "=" + System.Web.HttpUtility.UrlEncode(param.Value));
                    FirstParam = false;
                }
            }

            return Parametros == null ? string.Empty : Parametros.ToString();
        }

        public string Get(string url, Dictionary<string,string> parametros)
        {
            try
            {
                string responseFromServer = null;

                using (WebClient client = new WebClient())
                {
                    foreach (var p in parametros)
                    {
                        client.QueryString.Add(p.Key, p.Value);
                    }

                    Uri uri = new Uri(url);
                    UriBuilder builder = new UriBuilder(uri);
                    builder.Query = ConcatParams(parametros); 
                    responseFromServer = client.DownloadString(builder.Uri);
                }

                return responseFromServer;
            }
            catch (WebException ex)
            {
                if (ex.Status != WebExceptionStatus.Success)
                    throw new Exception("Not found remote service " + url);
                else throw ex;
            }
        }


    }
}
