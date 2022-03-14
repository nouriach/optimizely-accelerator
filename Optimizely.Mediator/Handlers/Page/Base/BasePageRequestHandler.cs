using MediatR;
using Optimizely.Mediator.Requests.Page;
using Optimizely.Models.Base;
using Optimizely.ViewModels.Pages.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Page.Base
{
    public class BasePageRequestHandler<T> where T : SitePageData
    {
        protected readonly IMediator _mediator;

        public BasePageRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public virtual async Task<BasePageViewModel> GetBasePageData(PageRequest<T> request, CancellationToken cancellationToken)
        {
            return new BasePageViewModel
            {
                // Header
                // Footer
                // Seo Data
            };
        }
    }
}
