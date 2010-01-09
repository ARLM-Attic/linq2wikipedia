using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Net;
using System.IO;

namespace LinqToWikipedia
{
    internal static class WikipediaOpenSearchRequest
    {
        internal static string Send(Type elementType, Expression expression)
        {
            WikipediaOpenSearchUriBuilder uriBuilder = new WikipediaOpenSearchUriBuilder(elementType);

            string xml = string.Empty;

            Uri uri = uriBuilder.BuildUri(expression);

            HttpWebResponse webResponse;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);

                webRequest.Proxy = null;
                //webRequest.Proxy = new WebProxy("gpproxy.geico.net", 80);
                //webRequest.Proxy.Credentials = new NetworkCredential("a85369", "Chargers09", "geico");

                webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (HttpListenerException httperr)
            {
                throw new LinqToWikipediaException(httperr.Message, httperr);
            }
            catch (Exception e)
            {
                throw new LinqToWikipediaException(e.Message, e);
            }

            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                    xml = sr.ReadToEnd();
            }

            return xml;
        }
    }
}
