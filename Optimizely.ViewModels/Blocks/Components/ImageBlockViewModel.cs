using Dept.Core.Constants;
using Optimizely.ViewModels.Blocks.Base;
using Optimizely.ViewModels.Media;

namespace Optimizely.ViewModels.Blocks.Components
{
    public class ImageBlockViewModel : BaseBlockViewModel
    {
        public override string ComponentName => ComponentNameConstants.Image;
        public ImageViewModel Image { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
    }
}
