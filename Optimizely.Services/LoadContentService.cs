using EPiServer;
using EPiServer.Core;
using Optimizely.Interfaces;
using Optimizely.Models.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Optimizely.Services
{
    public class LoadContentService : ILoadContentService
    {
        private readonly IContentLoader _contentLoader;

        public LoadContentService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader ?? throw new ArgumentNullException(nameof(contentLoader));
        }
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
            if (contentReference == null) return default(T);

            return _contentLoader.Get<T>(contentReference, language);
        }

        public IList<SiteBlockData> LoadBlockDataFromContentReferences(IList<ContentReference> references, CultureInfo language)
        {
            if (references == null) return default;

            return references
                .Select(reference => LoadBlock<SiteBlockData>(reference, language))
                .Where(block => block != null).ToList();
        }

        public IList<T> LoadBlockDataFromContentReferences<T>(IList<ContentReference> references, CultureInfo language)
        {
            return LoadBlockDataFromContentReferences(references, language)?.Cast<T>().ToList();
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
