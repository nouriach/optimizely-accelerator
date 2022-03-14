using MediatR;
using Optimizely.Core.Helpers;
using Optimizely.Mediator.Handlers.Page.Base;
using Optimizely.Mediator.Requests.Page;
using Optimizely.Models.Pages;
using Optimizely.ViewModels.Pages.Components;
using Optimizely.ViewModels.Pages.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Page
{
    public class BasicContentPageRequestHandler : BasePageRequestHandler<BasicContentPage>, IRequestHandler<PageRequest<BasicContentPage>, ISitePageViewModel>
    {
        public BasicContentPageRequestHandler(IMediator mediator) : base(mediator){ }

        public async Task<ISitePageViewModel> Handle(PageRequest<BasicContentPage> request, CancellationToken cancellationToken)
        {
            var page = request?.Page;
            var baseModel = await base.GetBasePageData(request, cancellationToken);

            return new BasicContentPageViewModel(baseModel)
            {
                Title = page?.Title,
                MainRegion = page?.MainRegion,
                MainBody = page?.MainBody.ToHtmlStringWithExternalLinks()
            };
        }
    }
}
