using MediatR;
using Optimizely.Core.Helpers;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Mediator.Requests.Image;
using Optimizely.Models.Blocks;
using Optimizely.Models.Media;
using Optimizely.ViewModels.Blocks.Components;
using Optimizely.ViewModels.Blocks.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block
{
    public class ImageBlockRequestHandler : IRequestHandler<BlockRequest<ImageBlock>, ISiteBlockViewModel>
    {
        private readonly ILoadContentService _loadContentService;
        private readonly IMediator _mediator;

        public ImageBlockRequestHandler(ILoadContentService loadContentService, IMediator mediator)
        {
            _loadContentService = loadContentService;
            _mediator = mediator;
        }
        public async Task<ISiteBlockViewModel> Handle(BlockRequest<ImageBlock> request, CancellationToken cancellationToken)
        {
            var block = request?.Block;
            var imageFile = _loadContentService.LoadBlock<ImageFile>(block?.Image, request?.Language);
            var imageViewModel = await _mediator.Send(new ImageFileRequest(imageFile, request?.Language), cancellationToken);

            return new ImageBlockViewModel
            {
                Image = imageViewModel,
                Description = block?.Description.ToHtmlStringWithExternalLinks(),
                Caption = block?.Caption
            };
        }
    }
}
