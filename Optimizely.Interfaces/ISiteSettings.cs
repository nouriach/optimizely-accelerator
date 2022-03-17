using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizely.Interfaces
{
    public interface ISiteSettings
    {
        PageReference ConfigurationPage { get; }
        PageReference StartPageReference { get; }
    }
}
