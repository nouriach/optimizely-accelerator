using MediatR;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.ViewModels.Blocks.Interfaces;
using Optimizely.ViewModels.Global.Components;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block.Global
{
    public class FooterBlockRequestHandler : IRequestHandler<FooterRequest, FooterViewModel>
    {
        private readonly IConfigService _configService;

        public FooterBlockRequestHandler(IConfigService configService)
        {
            _configService = configService;
        }
        public async Task<FooterViewModel> Handle(FooterRequest request, CancellationToken cancellationToken)
        {
            var footerBlock = _configService?.Footer;

            return new FooterViewModel
            {
                Title = footerBlock?.Title
            };
        }
    }
}
