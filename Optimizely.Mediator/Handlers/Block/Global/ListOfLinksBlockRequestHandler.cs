using MediatR;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks.Global;
using Optimizely.ViewModels.Blocks.Interfaces;
using Optimizely.ViewModels.Global.Components;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block.Global
{
    public class ListOfLinksBlockRequestHandler : IRequestHandler<BlockRequest<ListOfLinksBlock>, ISiteBlockViewModel>
    {
        private readonly IMediator _mediator;
        private readonly ILoadContentService _loadContentService;
        public ListOfLinksBlockRequestHandler(IMediator mediator, ILoadContentService loadContentService)
        {
            _mediator = mediator;
            _loadContentService = loadContentService;
        }

        public async Task<ISiteBlockViewModel> Handle(BlockRequest<ListOfLinksBlock> request, CancellationToken cancellationToken)
        {
            var block = request?.Block;
            var links = _loadContentService.LoadBlockDataFromContentReferences<LinkBlock>(block?.Links, request?.Language);

            var linkViewModels = new List<LinkBlockViewModel>();

            if (links != null)
                foreach (var link in links)
                {
                    var viewModel =
                        await _mediator.Send(BlockRequest.Create(link, request?.Language), cancellationToken) as LinkBlockViewModel;

                    if (viewModel != null) linkViewModels.Add(viewModel);
                }

            return new ListOfLinksBlockViewModel
            {
                Links = linkViewModels
            };
        }
    }
}
