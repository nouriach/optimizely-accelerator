using System;
using EPiServer;
using EPiServer.Core;

namespace Optimizely.Interfaces
{
    public interface IUrlHelper
    {
        string GetTidyUrl(Url url);
        string GetTidyUrl(IContent content);
    }
}
