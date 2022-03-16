using Dept.Core.Constants;
using Optimizely.ViewModels.Blocks.Base;

namespace Optimizely.ViewModels.Global.Components
{
    public class HeaderViewModel : BaseBlockViewModel
    {
        public override string ComponentName => ComponentNameConstants.Header;
        public string Title { get; set; }
    }
}
