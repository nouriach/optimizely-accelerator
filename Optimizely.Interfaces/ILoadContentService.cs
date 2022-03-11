using EPiServer.Core;
using Optimizely.Models.Base;
using System.Collections.Generic;
using System.Globalization;

namespace Optimizely.Interfaces
{
    public interface ILoadContentService
    {
        List<IContent> LoadContentArea(ContentArea contentArea, CultureInfo language);
        List<IContent> LoadContent(IEnumerable<ContentAreaItem> contentAreaItems);
        T LoadBlock<T>(ContentReference contentReference, CultureInfo language) where T : IContentData;
        SitePageData LoadPageData(ContentReference contentReference, CultureInfo language);
        IEnumerable<T> LoadAllPages<T>() where T : SitePageData;
        IEnumerable<T> LoadAllBlocks<T>() where T : SiteBlockData;
        IList<SiteBlockData> LoadBlockDataFromContentReferences(IList<ContentReference> references, CultureInfo language);
        IList<SitePageData> LoadPageDataFromContentReferences(IList<ContentReference> references, CultureInfo language);
        IList<T> LoadBlockDataFromContentReferences<T>(IList<ContentReference> references, CultureInfo language);
        T LoadContentByContentLinkId<T>(int contentLinkId, CultureInfo language) where T : IContentData;
    }
}
