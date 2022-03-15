using MediatR;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Image;
using Optimizely.ViewModels.Media;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Handlers.Block
{
    public class ImageFileRequestHandler : IRequestHandler<ImageFileRequest, ImageViewModel>
    {
        private readonly IUrlHelper _urlHelper;
        public ImageFileRequestHandler(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }
        public async Task<ImageViewModel> Handle(ImageFileRequest request, CancellationToken cancellationToken)
        {
            if (request?.ImageFile == null) 
                return null;

            var imageUrl = _urlHelper.GetTidyUrl(request.ImageFile);

            return new ImageViewModel
            {
                Mobile = new ImageDataViewModel { Url = imageUrl },
                Tablet = new ImageDataViewModel { Url = imageUrl },
                Desktop = new ImageDataViewModel { Url = imageUrl },
                LargeDesktop = new ImageDataViewModel { Url = imageUrl },
                AltText = "Placeholder AltText"
            };
        }
    }
}
