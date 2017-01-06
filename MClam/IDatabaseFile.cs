using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MClam.Native;

namespace MClam
{
    public interface IDatabaseFile
    {
        string FullPath { get; }
    }
}
