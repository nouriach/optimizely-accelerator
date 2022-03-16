using Dept.Core.Constants;
using Optimizely.ViewModels.Blocks.Base;

namespace Optimizely.ViewModels.Global.Components
{
    public class FooterViewModel : BaseBlockViewModel
    {
        public override string ComponentName => ComponentNameConstants.Footer;
        public string Title { get; set; }
    }
}
