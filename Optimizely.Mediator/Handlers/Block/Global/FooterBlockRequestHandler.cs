using MediatR;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks.Global;
using Optimizely.ViewModels.Blocks.Interfaces;
using Optimizely.ViewModels.Global.Components;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block.Global
{
    public class FooterBlockRequestHandler : IRequestHandler<BlockRequest<FooterBlock>, ISiteBlockViewModel>
    {
        public async Task<ISiteBlockViewModel> Handle(BlockRequest<FooterBlock> request, CancellationToken cancellationToken)
        {
            var block = request?.Block;

            return new FooterViewModel
            {
                Title = block?.Title
            };
        }
    }
}
