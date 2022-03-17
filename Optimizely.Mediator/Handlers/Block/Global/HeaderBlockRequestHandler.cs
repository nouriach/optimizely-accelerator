using MediatR;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks.Global;
using Optimizely.ViewModels.Blocks.Interfaces;
using Optimizely.ViewModels.Global.Components;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block.Global
{
    public class HeaderBlockRequestHandler : IRequestHandler<HeaderRequest, HeaderViewModel>
    {
        private readonly IConfigService _configService;

        public HeaderBlockRequestHandler(IConfigService configService)
        {
            _configService = configService;
        }
        public async Task<HeaderViewModel> Handle(HeaderRequest request, CancellationToken cancellationToken)
        {
            var headerBlock = _configService?.Header;

            return new HeaderViewModel
            {
                Title = headerBlock?.Title
            };
        }
    }
}
