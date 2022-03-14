using EPiServer.Core;

namespace Optimizely.Models.Base
{
    public class SitePageData : PageData
    {
        public SitePageData(){}

        public SitePageData(PageReference pageReference) : base(pageReference) { }

    }
}
