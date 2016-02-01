using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Parcer
{
    public class AutoBaraholkaParcer : Parcer
    {
        public static Regex Regex { get; set; } = new Regex(@"\+375.+\d");

        public AutoBaraholkaParcer()
        {
            Uri = new Uri("http://ab.onliner.by/search");
        }
        
        public List<Auto> Parce()
        {
            PostRequest();
            var autos = ParceResponce();
            var task = GetPhones(autos);
            task.Wait();
            return autos;
        }

        protected override void PostRequest()
        {
            try
            {
                var builder = new WebRequestBuilder("ab.onliner.by", Uri, "http://ab.onliner.by")
                { Method = "post", Accept = "application/json, text/javascript, */*; q=0.01"};
                var wReq = builder.Build();

                using (var resp = (HttpWebResponse)wReq.GetResponse())
                {

                    using (var sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        Response = sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private List<Auto> ParceResponce()
        {
            return ((JObject)JsonConvert.DeserializeObject(Response))["result"]["advertisements"]
                .Select(x => new Auto
                {
                    Id = (int)x.First["id"],
                    Name = x.First["title"].ToString()
                })
                .ToList();
        }

        private static async Task GetPhones(IEnumerable<Auto> autos)
        {
            var tasks = autos.Select(async auto =>  await auto.GetPhones()).ToList();
            await Task.WhenAll(tasks);
        }
    }
}
