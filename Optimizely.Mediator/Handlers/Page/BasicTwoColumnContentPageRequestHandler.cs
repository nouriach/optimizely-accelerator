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
    public class BasicTwoColumnContentPageRequestHandler : BasePageRequestHandler<BasicTwoColumnContentPage>, IRequestHandler<PageRequest<BasicTwoColumnContentPage>, ISitePageViewModel>
    {
        public BasicTwoColumnContentPageRequestHandler(IMediator mediator) : base(mediator) {}
        public async Task<ISitePageViewModel> Handle(PageRequest<BasicTwoColumnContentPage> request, CancellationToken cancellationToken)
        {
            var page = request?.Page;
            var baseModel = await base.GetBasePageData(request, cancellationToken);

            return new BasicTwoColumnContentPageViewModel(baseModel)
            {
                Title = page?.Title,
                RightColumn = page?.RightColumn,
                LeftColumn = page?.LeftColumn,
                MainBody = page?.MainBody.ToHtmlStringWithExternalLinks()
            };
        }
    }
}
