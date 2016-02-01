using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parcer
{
    public class Auto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> PhoneNumbers { get; set; } = new List<string>();
    }
}
