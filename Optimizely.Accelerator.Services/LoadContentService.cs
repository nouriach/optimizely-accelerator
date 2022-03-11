using EPiServer.Core;
using Optimizely.Accelerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizely.Accelerator.Services
{
    public class LoadContentService : ILoadContentService
    {
        public IEnumerable<T> LoadAllBlocks<T>() where T : SiteBlockData
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> LoadAllPages<T>() where T : SitePageData
        {
            throw new NotImplementedException();
        }

        public T LoadBlock<T>(ContentReference contentReference, CultureInfo language) where T : IContentData
        {
            throw new NotImplementedException();
        }

        public IList<SiteBlockData> LoadBlockDataFromContentReferences(IList<ContentReference> references, CultureInfo language)
        {
            throw new NotImplementedException();
        }

        public IList<T> LoadBlockDataFromContentReferences<T>(IList<ContentReference> references, CultureInfo language)
        {
            throw new NotImplementedException();
        }

        public List<IContent> LoadContent(IEnumerable<ContentAreaItem> contentAreaItems)
        {
            throw new NotImplementedException();
        }

        public List<IContent> LoadContentArea(ContentArea contentArea, CultureInfo language)
        {
            throw new NotImplementedException();
        }

        public T LoadContentByContentLinkId<T>(int contentLinkId, CultureInfo language) where T : IContentData
        {
            throw new NotImplementedException();
        }

        public SitePageData LoadPageData(ContentReference contentReference, CultureInfo language)
        {
            throw new NotImplementedException();
        }

        public IList<SitePageData> LoadPageDataFromContentReferences(IList<ContentReference> references, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
