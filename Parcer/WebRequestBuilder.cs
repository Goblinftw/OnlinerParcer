using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parcer
{
    public class WebRequestBuilder
    {
        public string Host { get; set; }

        public Uri Uri { get; set; }

        public string UserAgent { get; set; } =
            "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:44.0) Gecko/20100101 Firefox/44.0";

        public string Referer { get; set; }

        public string Method { get; set; } = "get";

        public string Accept { get; set; }

        public WebRequestBuilder(string host, Uri uri, string referer)
        {
            Host = host;
            Uri = uri;
            Referer = referer;
        }

        public WebRequest Build()
        {
            var req = (HttpWebRequest)WebRequest.Create(Uri);
            req.Host = Host;
            req.Referer = Referer;
            req.Method = Method;
            req.UserAgent = UserAgent;
            req.Accept = Accept;

            return req;
        }
    }
}
