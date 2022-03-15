using Optimizely.ViewModels.Blocks.Base;
using Optimizely.ViewModels.Media;

namespace Optimizely.ViewModels.Blocks.Components
{
    public class ImageBlockViewModel : BaseBlockViewModel
    {
        public ImageViewModel Image { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
    }
}
