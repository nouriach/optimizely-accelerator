using EPiServer;
using EPiServer.Web.Routing;
using Optimizely.Interfaces;
using Optimizely.Models.Base;
using Optimizely.ViewModels.Blocks.Components;
using System.Linq;

namespace Optimizely.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IContentLoader _loader;
        private readonly IUrlHelper _urlHelper;
        private readonly IPageRouteHelper _pageRouteHelper;

        public NavigationService(IContentLoader loader, IUrlHelper urlHelper, IPageRouteHelper pageRouteHelper)
        {
            _loader = loader;
            _urlHelper = urlHelper;
            _pageRouteHelper = pageRouteHelper;
        }

        public NavigationItem GetHomepage()
        {
            var currentPage = _pageRouteHelper.Page.ContentLink;
            var homepage = _loader.GetAncestors(currentPage).OfType<SitePageData>().Last();

            return new NavigationItem
            {
                Title = homepage?.Name,
                Url = _urlHelper.GetTidyUrl(homepage),
                PageData = homepage
            };
        }
    }
}
