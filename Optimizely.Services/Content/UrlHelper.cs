using EPiServer.Web.Routing;
using System;
using EPiServer;
using EPiServer.Web;
using Optimizely.Interfaces;
using EPiServer.Globalization;
using EPiServer.Core;

namespace Optimizely.Services.Content
{
    public class UrlHelper : IUrlHelper
    {
        private readonly IUrlResolver _urlResolver;

        public UrlHelper(IUrlResolver urlResolver)
        {
            _urlResolver = urlResolver ?? throw new ArgumentNullException(nameof(urlResolver));
        }

        public string GetTidyUrl(IContent content)
        {
            if (content == null) return null;
            var url = _urlResolver.GetUrl(content.ContentLink, ContentLanguage.PreferredCulture.Name);
            return GetTidyUrl(url);
        }

        public string GetTidyUrl(Url url)
        {
            if (url == null || url.IsEmpty())
                return string.Empty;

            return _urlResolver.GetUrl(new UrlBuilder(url), ContextMode.Default);
        }
    }
}
