using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parcer
{
    internal static class ExtentionMethods
    {
        internal static async Task GetPhones(this Auto auto)
        {
            try
            {
                var sb = new StringBuilder("http://ab.onliner.by/car/");
                sb.Append(auto.Id);
                WebRequestBuilder builder = new WebRequestBuilder("ab.onliner.by", new Uri(sb.ToString()), "http://ab.onliner.by");
                var wReq = builder.Build();

                using (var resp = (HttpWebResponse)await wReq.GetResponseAsync())
                {

                    using (var sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        var html = sr.ReadToEnd();
                        var match = AutoBaraholkaParcer.Regex.Match(html);
                        while (match.Success)
                        {
                            auto.PhoneNumbers.Add(match.Value);
                            match = match.NextMatch();
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
