using MediatR;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks;
using Optimizely.ViewModels.Blocks.Components;
using Optimizely.ViewModels.Blocks.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Optimizely.Interfaces;

namespace Optimizely.Mediator.Handlers.Block
{
    public class NavigationBlockRequestHandler : IRequestHandler<BlockRequest<NavigationBlock>, ISiteBlockViewModel>
    {
        private readonly INavigationService _navigationService;

        public NavigationBlockRequestHandler(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public async Task<ISiteBlockViewModel> Handle(BlockRequest<NavigationBlock> request, CancellationToken cancellationToken)
        {
            var block = request?.Block;
            var homepage = _navigationService.GetHomepage();

            return new NavigationBlockViewModel
            {
                Heading = block?.Heading,
                Homepage = homepage
            };
        }
    }
}
