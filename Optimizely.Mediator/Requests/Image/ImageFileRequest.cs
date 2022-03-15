using MediatR;
using Optimizely.Models.Media;
using Optimizely.ViewModels.Media;
using System.Globalization;

namespace Optimizely.Mediator.Requests.Image
{
    public class ImageFileRequest : IRequest<ImageViewModel>
    {
        public ImageFileRequest(ImageFile imageFile, CultureInfo language,  int placeHolderWidth = 500, int placeHolderHeight = 500)
        {
            ImageFile = imageFile;
            Language = language;
            PlaceHolderWidth = placeHolderWidth;
            PlaceHolderHeight = placeHolderHeight;
        }

        public ImageFile ImageFile { get; }
        public CultureInfo Language { get; }
        public int PlaceHolderWidth { get; set; }
        public int PlaceHolderHeight { get; set; }
    }
}
