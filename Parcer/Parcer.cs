using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parcer
{
    public abstract class Parcer
    {

        protected Uri Uri { get; set; }

        protected string Response { get; set; }

        protected abstract void PostRequest();

    }
}
