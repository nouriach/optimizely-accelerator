using MediatR;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks.Global;
using Optimizely.ViewModels.Blocks.Interfaces;
using Optimizely.ViewModels.Global.Components;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block.Global
{
    public class HeaderBlockRequestHandler : IRequestHandler<BlockRequest<HeaderBlock>, ISiteBlockViewModel>
    {
        public async Task<ISiteBlockViewModel> Handle(BlockRequest<HeaderBlock> request, CancellationToken cancellationToken)
        {
            var block = request?.Block;

            return new HeaderViewModel
            {
                Title = block?.Title
            };
        }
    }
}
