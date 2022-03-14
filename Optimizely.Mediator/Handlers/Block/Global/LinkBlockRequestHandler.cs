using MediatR;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks.Global;
using Optimizely.ViewModels.Blocks.Interfaces;
using Optimizely.ViewModels.Global.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block.Global
{
    public class LinkBlockRequestHandler : IRequestHandler<BlockRequest<LinkBlock>, ISiteBlockViewModel>
    {
        private readonly IUrlHelper _urlHelper;

        public LinkBlockRequestHandler(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        public async Task<ISiteBlockViewModel> Handle(BlockRequest<LinkBlock> request, CancellationToken cancellationToken)
        {
            var block = request?.Block;
            var url = _urlHelper.GetTidyUrl(block?.Url);

            return new LinkBlockViewModel
            {
                Name = block?.Name,
                Target = block?.Target,
                Url = url
            };
        }
    }
}
