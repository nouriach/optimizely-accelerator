using EPiServer.Web.Routing;
using System;
using EPiServer;
using EPiServer.Web;
using Optimizely.Interfaces;

namespace Optimizely.Services.Content
{
    public class UrlHelper : IUrlHelper
    {
        private readonly IUrlResolver _urlResolver;

        public UrlHelper(IUrlResolver urlResolver)
        {
            _urlResolver = urlResolver ?? throw new ArgumentNullException(nameof(urlResolver));
        }

        public string GetTidyUrl(Url url)
        {
            if (url == null || url.IsEmpty())
                return string.Empty;

            return _urlResolver.GetUrl(new UrlBuilder(url), ContextMode.Default);
        }
    }
}
