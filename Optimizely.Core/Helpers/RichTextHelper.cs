using System.Text;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Html.StringParsing;
using EPiServer.Web;
using EPiServer.Web.Routing;

namespace Optimizely.Core.Helpers
{
    public static class RichTextHelper
    {
        public static string ToHtmlStringWithExternalLinks(this XhtmlString xhtmlString)
        {
            var result = new StringBuilder();

            if (xhtmlString?.Fragments?.GetFilteredFragments() == null)
                return result.ToString();

            foreach (var fragment in xhtmlString.Fragments.GetFilteredFragments())
            {
                var urlFragment = fragment as UrlFragment;
                result.Append(urlFragment != null ?
                    UrlResolver.Current.GetUrl(new UrlBuilder(urlFragment.InternalFormat), ContextMode.Default) : fragment.GetViewFormat());
            }

            return result.ToString();
        }
    }
}
