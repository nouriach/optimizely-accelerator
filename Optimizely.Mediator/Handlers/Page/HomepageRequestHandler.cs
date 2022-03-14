using MediatR;
using Optimizely.Mediator.Handlers.Page.Base;
using Optimizely.Mediator.Requests.Page;
using Optimizely.Models.Pages;
using Optimizely.ViewModels.Pages.Components;
using Optimizely.ViewModels.Pages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Page
{
    public class HomepageRequestHandler : BasePageRequestHandler<Homepage>, IRequestHandler<PageRequest<Homepage>, ISitePageViewModel>
    {
        public HomepageRequestHandler(IMediator mediator) : base(mediator){}

        public async Task<ISitePageViewModel> Handle(PageRequest<Homepage> request, CancellationToken cancellationToken)
        {
            var page = request?.Page;
            var baseModel = await base.GetBasePageData(request, cancellationToken);

            return new HomepageViewModel(baseModel)
            {
                Title = page?.Title
            };
        }
    }
}
